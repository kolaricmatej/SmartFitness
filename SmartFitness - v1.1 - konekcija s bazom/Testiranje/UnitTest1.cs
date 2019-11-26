using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartFitness;
using System.Collections.Generic;
using System.Windows.Forms;
using Unos_sporta;

namespace Testiranje
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            SmartFitness.ucenik ucenik = null;
            ucenik = SmartFitness.ucenik.DohvatiUcenikaPoIdu(3866);
            Assert.IsNull(ucenik);

        }

        [TestMethod]
        public void Test2()
        {
           SmartFitness.vjezba vjezba = null;
            vjezba =SmartFitness.vjezba.DohvatiVjezbuPoIdu(12345);
            Assert.IsNull(vjezba);
        }
        [TestMethod]
        public void Test3()
        {
           SmartFitness.natjecanje natjecanje = null;
            natjecanje =SmartFitness.natjecanje.DohvatiNatjecanjePomocuId(54984);
            Assert.IsNull(natjecanje);
        }


    }
}
