namespace ImpactMan.Models.Players.Events
{
    using System;
    using Microsoft.Xna.Framework;

    public class PlayerTriedToMoveEventArgs : EventArgs
    {
        private Rectangle desiredPosition;

        public PlayerTriedToMoveEventArgs(Rectangle desiredPosition)
        {
            this.DesiredPosition = desiredPosition;
        }

        public Rectangle DesiredPosition
        {
            get
            {
                return this.desiredPosition;
            }

            private set
            {
                this.desiredPosition = value;
            }
        }
    }
}
