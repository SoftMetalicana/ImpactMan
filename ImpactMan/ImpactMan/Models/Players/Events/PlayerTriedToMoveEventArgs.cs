namespace ImpactMan.Models.Players.Events
{
    using System;
    using Microsoft.Xna.Framework;

    public class PlayerTriedToMoveEventArgs : EventArgs
    {
        private Rectangle desiredPosition;
        private Rectangle helperRectangle;

        public PlayerTriedToMoveEventArgs(Rectangle desiredPosition, Rectangle helperRectangle)
        {
            this.DesiredPosition = desiredPosition;
            this.HelperRectangle = helperRectangle;
        }

        public Rectangle HelperRectangle
        {
            get
            {
                return this.helperRectangle;
            }

            private set
            {
                this.helperRectangle = value;
            }
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
