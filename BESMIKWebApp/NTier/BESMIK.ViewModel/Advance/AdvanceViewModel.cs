﻿using BESMIK.Common;
using BESMIK.ViewModel.AppUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BESMIK.ViewModel.Advance
{
    public class AdvanceViewModel : BaseViewModel
    {
        public DateOnly AdvanceRequestDate { get; set; } 
        public AdvanceApprovalStatus ApprovalStatus { get; set; } 
        public DateOnly? AdvanceResponseDate { get; set; } 
        public float Amount { get; set; } 
        public AdvanceCurrency Currency { get; set; } 
        public string Description { get; set; } 
        public AdvanceType AdvanceType { get; set; }


        public int AppUserId { get; set; }
        public AppUserViewModel? AppUser { get; set; }
    }
}
