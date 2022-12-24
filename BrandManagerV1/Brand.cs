﻿namespace BrandManagerV1
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }

        public Brand(string name, bool isEnabled)
        {
            Name = name;
            IsEnabled = isEnabled;
        }

    }
}
