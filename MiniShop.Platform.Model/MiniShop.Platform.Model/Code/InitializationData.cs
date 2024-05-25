﻿using System.Collections.Generic;

namespace MiniShop.Platform.Model.Code
{
    public class InitializationData
    {
        public List<RenewPackage> RenewPackage { get; set; } = new List<RenewPackage>()
        {
            new RenewPackage {
                Id=1,
                Name="半年",
                Price=299,
                Months=6,
                Image="https://gw.alipayobjects.com/zos/rmsportal/gLaIAoVWTtLbBWZNYEMg.png",
                Remark="续费请联系：18276743761（微信同号）"
            },
            new RenewPackage{
                Id=2,
                Name="一年",
                Price=499,
                Months=12,
                Image="https://gw.alipayobjects.com/zos/rmsportal/iXjVmWVHbCJAyqvDxdtx.png",
                Remark="续费请联系：18276743761（微信同号）"
            },
            new RenewPackage{
                Id=3,
                Name="两年",
                Price=799,
                Months=24,
                Image="https://gw.alipayobjects.com/zos/rmsportal/iZBVOIhGJiAnhplqjvZW.png",
                Remark="续费请联系：18276743761（微信同号）"
            },
            new RenewPackage{
                Id=4,
                Name="三年",
                Price=1099,
                Months=36,
                Image="https://gw.alipayobjects.com/zos/rmsportal/uMfMFlvUuceEyPpotzlq.png",
                Remark="续费请联系：18276743761（微信同号）"
            }
        };

        public static InitializationData Initialization { get; set; } = new InitializationData();
    }
}
