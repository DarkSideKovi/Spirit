using System;
using System.Collections.Generic;
using System.Text;

namespace Spirit.Domain
{
    public sealed class RateCard
    {
        public int BaseFee { get; init; }
        public int FeePerKg { get; init; }
        public int FeePerCbm { get; init; }
        public int FeePerKm { get; init; }
        public int ExtraFee { get; init; }

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
