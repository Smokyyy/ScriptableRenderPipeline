using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

namespace UnityEditor.ShaderGraph
{
    class RedirectNodeCreationContext : NodeCreationContext
    {
        public Edge edge;
    }

    public class RedirectNode : Node
    {
        public RedirectNode()
        {
            UseRedirectStyling();
        }

        void UseRedirectStyling()
        {
            styleSheets.Add(Resources.Load<StyleSheet>("Styles/RedirectNode"));
        }
    }
}
