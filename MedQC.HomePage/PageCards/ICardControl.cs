using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heren.MedQC.HomePage.PageCards
{
    public interface ICardControl
    {
        bool RefreshCard();
        bool Export();
    }

}
