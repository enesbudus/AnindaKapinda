﻿using AnindaKapinda.Core.DataAccess.EntityFramework;
using AnindaKapinda.DataAccess.Abstract;
using AnindaKapinda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnindaKapinda.DataAccess.Concrete.EntityFramework.Repositories
{
   public class KargoRepository: EFRepositoryBase<Kargo, AnindaKapindaDBContext>,IKargoDAL
    {
    }
}
