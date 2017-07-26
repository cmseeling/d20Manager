﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CampaignManager.Data.Models
{
    public class CharacterItem
    {
        public int CharacterId { get; set; }
        public Character Character { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
