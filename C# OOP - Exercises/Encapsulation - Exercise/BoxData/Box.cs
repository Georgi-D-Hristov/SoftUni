namespace BoxData
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Height
        {
            get
            {
                return height;
            }
            private set
            {
                IsValid(value, nameof(Height));
                height = value;
            }
        }

        public double Width
        {
            get
            {
                return width;
            }
            private set
            {
                IsValid(value, nameof(Width));
                width = value;
            }
        }


        public double Length
        {
            get
            {
                return length;
            }
            private set
            {
                IsValid(value, nameof(Length));
                length = value;
            }
        }

        public double SurfaceArea()
        {
            var surfaceArea = 2 * Length * Width + 2 * Length * Height + 2 * Width * Height;

            return surfaceArea;
        }

        public double LateralSurfaceArea()
        {
            var lateralSurfaceArea = 2 * Length * Height + 2 * Width * Height;

            return lateralSurfaceArea;
        }

        public double Volume()
        {
            var volume = Length * Width * Height;
            return volume;
        }


        private void IsValid(double value, string propertyName)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{propertyName} cannot be zero or negative.");
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            result.AppendLine($"Surface Area - {SurfaceArea():f2}");
            result.AppendLine($"Lateral Surface Area - {LateralSurfaceArea():f2}");
            result.AppendLine($"Volume - {Volume():f2}");
            return result.ToString().TrimEnd();
        }
    }
}
