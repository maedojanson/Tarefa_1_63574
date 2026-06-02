using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Subclass of Unit that will transport resource from a Resource Pile back to Base.
/// </summary>
public class TransporterUnit : Unit
{
    public int MaxAmountTransported = 1;

    private Building m_CurrentTransportTarget;
    private Building.InventoryEntry m_Transporting = new Building.InventoryEntry();

    // 🎨 MÁGICA DO PRISMA: Ativa-se assim que a empilhadora nasce na cena!
    void Start()
    {
        if (MainManager.Instance != null)
        {
            // 1. Procura o componente que controla as cores e luzes (ColorHandler) na empilhadora
            ColorHandler colorHandler = GetComponentInChildren<ColorHandler>();
            
            if (colorHandler != null)
            {
                // 2. Aplica a tua cor diretamente ao prisma usando o sistema do jogo!
                colorHandler.SetColor(MainManager.Instance.TeamColor);
            }
            else
            {
                // 3. CASO DE EMERGÊNCIA: Se o ColorHandler não estiver lá, muda o material diretamente pelo Renderer
                Renderer meshRenderer = GetComponentInChildren<Renderer>();
                if (meshRenderer != null && meshRenderer.material != null)
                {
                    // Altera a cor principal e a cor emissiva (brilho) do material do prisma
                    meshRenderer.material.color = MainManager.Instance.TeamColor;
                    meshRenderer.material.SetColor("_EmissionColor", MainManager.Instance.TeamColor);
                }
            }
        }
    }

    // We override the GoTo function to remove the current transport target, as any go to order will cancel the transport
    public override void GoTo(Vector3 position)
    {
        base.GoTo(position);
        m_CurrentTransportTarget = null;
    }
    
    protected override void BuildingInRange()
    {
        if (m_Target == Base.Instance)
        {
            //we arrive at the base, unload!
            if (m_Transporting.Count > 0)
                m_Target.AddItem(m_Transporting.ResourceId, m_Transporting.Count);

            //we go back to the building we came from
            GoTo(m_CurrentTransportTarget);
            m_Transporting.Count = 0;
            m_Transporting.ResourceId = "";
        }
        else
        {
            if (m_Target.Inventory.Count > 0)
            {
                m_Transporting.ResourceId = m_Target.Inventory[0].ResourceId;
                m_Transporting.Count = m_Target.GetItem(m_Transporting.ResourceId, MaxAmountTransported);
                m_CurrentTransportTarget = m_Target;
                GoTo(Base.Instance);
            }
        }
    }
    
    //Override all the UI function to give a new name and display what it is currently transporting
    public override string GetName()
    {
        return "Transporter";
    }

    public override string GetData()
    {
        return $"Can transport up to {MaxAmountTransported}";
    }

    public override void GetContent(ref List<Building.InventoryEntry> content)
    {
        if (m_Transporting.Count > 0)
            content.Add(m_Transporting);
    }
}