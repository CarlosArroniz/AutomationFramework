// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Enum.cs" company="Scio Consulting">
//   Copyright ©  Scio Consulting. Todos los derechos estan reservados.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace ScioAutomationFramework.Enums
{
    /// <summary>The enum.</summary>
    public class Enum
    {
        /// <summary>The scroll.</summary>
        public enum scroll
        {
            /// <summary>The scroll up.</summary>
            scrollUp, 

            /// <summary>The scroll down.</summary>
            scrollDown, 

            /// <summary>The scroll left.</summary>
            scrollLeft, 

            /// <summary>The scroll rigth.</summary>
            scrollRigth
        }

        /// <summary>The visiblility state.</summary>
        public enum VisiblilityState
        {
            /// <summary>The visible.</summary>
            visible, 

            /// <summary>The hidden.</summary>
            hidden, 

            /// <summary>The collapse.</summary>
            collapse, 

            /// <summary>The initial.</summary>
            initial, 

            /// <summary>The inherit.</summary>
            inherit
        }
    }
}