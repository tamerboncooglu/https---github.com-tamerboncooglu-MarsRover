namespace MarsRover
{
    public class Rover
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public int Degree
        {
            get
            {
                return _degree;
            }
        }

        public Grid Grid { get; set; }

        private void SetDegree(int turnDegree)
        {
            _degree += turnDegree;

            if (_degree < 0)
                _degree = 360 + _degree;

            if (_degree >= 360)
                _degree = 0;
        }

        private int _degree;

        public void TurnLeft()
        {
            SetDegree(-90);
        }

        public void TurnRight()
        {
            SetDegree(90);
        }

        public void Move()
        {
            if (PositionX == 0 && Degree == 270)
            {
                throw new RoverNavigationException(Messages.NavigationErrorMessage);
            }

            if (PositionY == Grid.PointY && Degree == 0)
            {
                throw new RoverNavigationException(Messages.NavigationErrorMessage);
            }

            if (PositionX == Grid.PointX && Degree == 90)
            {
                throw new RoverNavigationException(Messages.NavigationErrorMessage);
            }

            if (PositionY == 0 && Degree == 180)
            {
                throw new RoverNavigationException(Messages.NavigationErrorMessage);
            }

            switch (this.Degree)
            {
                case 90: this.PositionX++; break;
                case 180: this.PositionY--; break;
                case 270: this.PositionX--; break;
                case 0: this.PositionY++; break;
            }
        }

        public string GetCamFace()
        {
            switch (this.Degree)
            {
                case 90: return "E";
                case 180: return "S";
                case 270: return "W";
                case 0: return "N";
                default: return "N";
            }
        }

        public void SetStartDirection(string direction)
        {
            switch (direction)
            {
                case "E": _degree = 90; break;
                case "S": _degree = 180; break;
                case "W": _degree = 270; break;
                case "N": _degree = 0; break;
            }
        }
    }
}