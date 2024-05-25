﻿using System.Collections.Generic;

namespace MiniShop.Backend.Model.Code
{
    public class InitializationData
    {
        public List<Shop> Shop { get; set; }
        public List<Categorie> Categorie { get; set; }
        public List<Unit> Unit { get; set; }
        public List<Item> Item { get; set; }

        public static InitializationData Initialization { get; set; } = new InitializationData();
    }
}
