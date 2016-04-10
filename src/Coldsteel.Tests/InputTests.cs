using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coldsteel.Tests.Doubles;

namespace Coldsteel.Tests
{
    [TestClass]
    public class InputTests
    {
        [TestMethod]
        public void CanAddControls()
        {
            var input = new Input();
            var control = new MockControl("control1");
            input.AddControl(control);
            Assert.IsTrue(input.Controls.Contains(control));
            var control2 = new MockControl("control2");
            input.AddControl(control2);
            Assert.IsTrue(input.Controls.Contains(control2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void MayNotAdd2ControlsWithTheSameKey()
        {
            var input = new Input();
            var control = new MockControl("control");
            input.AddControl(control);
            var control2 = new MockControl("control");
            input.AddControl(control2);
        }

        [TestMethod]
        public void MayGetControlByKey()
        {
            var input = new Input();
            var control = new MockControl("control");
            input.AddControl(control);
            var result = input.GetControl("control");
            Assert.AreSame(control, result);
        }

        [TestMethod]        
        [ExpectedException(typeof(ArgumentException))]
        public void ThrowsExceptionWhenGettingKeyThatDoesNotExist()
        {
            var input = new Input();
            var control = new MockControl("control");
            input.AddControl(control);
            input.GetControl("notcontrol");
        }

        [TestMethod]
        public void CanGetControlAsType()
        {
            var input = new Input();
            var control = new MockControl("control");
            input.AddControl(control);
            var result = input.GetControl<MockControl>("control");
            Assert.AreSame(control, result);
        }
    }
}
