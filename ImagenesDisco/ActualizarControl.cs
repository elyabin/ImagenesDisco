
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ImagenesDisco
{
    delegate void ActualizarControl(object pControl, string pPropiedad, string pValor);


    public class AuxiliarUI 
    {
        public void ActualizarControlSeguro(object pControl, string pPropiedad, object pValor)
        {
            if (pControl.GetType() == typeof(ProgressBar))
            {
                switch (pPropiedad)
                {
                    case "Value": ((ProgressBar)pControl).Value = Convert.ToInt32(pValor); break;
                }

            }
            else if (pControl.GetType() == typeof(Label))
            {
                switch (pPropiedad)
                {
                    case "Text": ((Label)pControl).Text = pValor.ToString(); break;
                }

            }

            else if (pControl.GetType() == typeof(System.Windows.Forms.StatusStrip))
            {
                switch (pPropiedad)
                {
                    case "Text0": ((StatusStrip)pControl).Items[0].Text = pValor.ToString(); break;
                }

            }

            else if (pControl.GetType() == typeof(System.Windows.Forms.TreeView) )
            {
                switch (pPropiedad)
                {
                    case "RAIZ": ((TreeView)pControl).Nodes[0].Nodes.Add(pValor.ToString());
                        if (((TreeView)pControl).Nodes[0].IsExpanded == false) 
                        {
                            ((TreeView)pControl).Nodes[0].Expand();
                        }
                        break;
                }

            }

            else if (pControl.GetType() == typeof(System.Windows.Forms.TreeNode))
            {
                switch (pPropiedad)
                {
                        
                    case "Add":
                        TreeNode nodoNuevo = new TreeNode(pValor.ToString());
                        

                        //((TreeNode)pControl).Nodes.Add(pValor.ToString());
                        ((TreeNode)pControl).Nodes.Add(nodoNuevo);
                        
                        break;
                }

            }

        }
    }

}
