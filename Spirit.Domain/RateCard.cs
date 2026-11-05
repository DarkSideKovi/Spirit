using System;
using System.Collections.Generic;
using System.Text;

namespace Spirit.Domain
{
    public sealed class RateCard
    {
        public int BaseFee { get; set; }
        public int FeePerKg { get; set; }
        public int FeePerCbm { get; set; }
        public int FeePerKm { get; set; }
        public int ExtraFee { get; set; }

        public RateCard(int baseFee, int feePerKg = 0, int feePerCbm = 0, int feePerKm = 0, int extraFee = 0)
        {
            BaseFee = baseFee;
            FeePerKg = feePerKg;
            ExtraFee = extraFee;
            FeePerCbm = feePerCbm;
            FeePerKm = feePerKm;
        }
    }
}
