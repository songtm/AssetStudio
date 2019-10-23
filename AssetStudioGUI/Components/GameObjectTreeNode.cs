using System.Windows.Forms;
using AssetStudio;

namespace AssetStudioGUI
{
    internal class GameObjectTreeNode : TreeNode
    {
        public GameObject gameObject;

        public GameObjectTreeNode(GameObject gameObject)
        {
            this.gameObject = gameObject;
            Text = gameObject.m_Name;
            System.Text.StringBuilder coms = new System.Text.StringBuilder();
            coms.Append("  [");
            foreach (var pptr in gameObject.m_Components)
            {
                if (pptr.TryGet(out var com))
                {
                    if (com is MonoBehaviour monoBehaviour)
                    {

                        if (monoBehaviour.m_Name == "" && monoBehaviour.m_Script.TryGet(out var m_Script))
                        {
                            coms.Append(m_Script.m_ClassName);
                        }
                        else
                        {
                            coms.Append(monoBehaviour.m_Name);
                        }
                    }else
                    {
                        var parts = com.ToString().Split('.');
                        coms.Append(parts[parts.Length - 1]);

                    }
                    coms.Append(" ");
                }
            }
            if (coms.Length > 1) coms.Remove(coms.Length - 1, 1);
            coms.Append("]");
            Text += coms;
        }
    }
}