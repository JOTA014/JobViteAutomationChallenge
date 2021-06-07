using Xunit;
using JobViteAutomationChallenge.Helper;
using JobViteAutomationChallenge.PageObject;

namespace JobViteAutomationChallenge
{
    public class ContactFormTests : BaseClass
    {
        private AutomationPracticePO automationPracticePO;
        private string Message = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Suspendisse commodo non velit et gravida. Etiam erat magna, sodales at aliquet sed, suscipit quis metus. Nulla hendrerit eleifend ante, ullamcorper sagittis felis porta nec. Aliquam consectetur tortor lectus, vel pretium metus egestas rutrum. Pellentesque accumsan condimentum nibh nec pharetra. In arcu ipsum, faucibus at mi et, tempor condimentum nisl. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Sed at mollis odio. Donec molestie efficitur augue, et ullamcorper tellus fermentum in.
Phasellus blandit libero eget mauris dignissim, venenatis elementum orci aliquam.Nam commodo lectus eget porta dignissim.Maecenas pretium vel ligula et accumsan.Aenean semper porttitor metus, eget posuere nunc vestibulum non.Quisque sit amet nisl luctus, finibus eros sit amet, imperdiet nisi. Fusce ornare feugiat nisi vel rutrum. Sed sit amet erat ac eros commodo condimentum vitae tempus quam.Quisque purus lectus, tempus vel molestie sit amet, semper eget mi.Cras fringilla ullamcorper nisi, sed efficitur ante varius sit amet.
Aliquam pulvinar elit congue blandit lobortis. Duis laoreet porttitor orci, vitae vulputate ligula accumsan vel.Fusce sit amet lacinia sem, bibendum elementum ligula.Aenean convallis sollicitudin ante ultrices tincidunt. Sed interdum sapien aliquam lorem suscipit, et vulputate enim placerat. Sed auctor diam eget metus hendrerit volutpat.Etiam viverra suscipit nisl, non blandit metus elementum vitae.Phasellus sollicitudin placerat nibh elementum tincidunt. Cras tincidunt vulputate volutpat. Aliquam condimentum est a arcu interdum mattis.Quisque turpis erat, aliquet ac felis sit amet, elementum dapibus velit.Vivamus eu erat quis orci dapibus posuere at ac nibh. Maecenas pretium dolor urna, non pellentesque ligula lacinia nec.Nam vel odio nisl.
Donec pretium sit amet metus non facilisis.Sed tempus mauris sem, quis viverra metus consectetur in. Nulla velit metus, varius at fermentum sit amet, fringilla at velit.Duis metus nibh, imperdiet eu lorem vel, rutrum eleifend purus.Donec quis urna a enim porta congue eget quis metus. Praesent ut vestibulum eros. Fusce in massa ac lacus interdum viverra blandit non diam. Aenean ut sapien ligula. Vestibulum et libero blandit, gravida metus id, porttitor augue. Nunc tincidunt lectus in euismod faucibus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.Nulla in felis ut lectus pellentesque ullamcorper.In hac habitasse platea dictumst.Integer malesuada scelerisque iaculis.
Morbi feugiat erat erat, non semper nibh vehicula sed.Mauris mattis ligula interdum feugiat consequat. Phasellus sit amet accumsan libero.Lorem ipsum dolor sit amet, consectetur adipiscing elit.Praesent auctor orci sit amet ipsum interdum, eget scelerisque orci lacinia. Integer posuere fermentum metus sit amet rhoncus.Donec porttitor metus at mauris porttitor, vel eleifend neque consectetur. Ut consectetur egestas mollis. Morbi viverra malesuada risus, eu vulputate neque malesuada in. Etiam ornare sapien ut nulla vestibulum tempus.In quis risus volutpat, euismod orci a, aliquet metus. Quisque in ligula sed tortor rhoncus tempus eget eu ligula. Vestibulum ornare iaculis ligula nec pellentesque. Duis vestibulum cursus est at dapibus. Vivamus pharetra vehicula mi, a malesuada mauris maximus quis.Ut porttitor justo in enim.";
        public ContactFormTests()
        {
            GetChromeDriver();
            automationPracticePO = new AutomationPracticePO(driver);
        }

        [Fact]
        public void ContactSendEmptyForm()
        {
            automationPracticePO.GoToPage();
            automationPracticePO.GoToContactUsForm();
            automationPracticePO.ContactClickSendMessageButton();
            Assert.True(automationPracticePO.IsThereAContactFormError());
        }

        [Fact]
        public void ContactSendValid()
        {
            automationPracticePO.GoToPage();
            automationPracticePO.GoToContactUsForm();
            automationPracticePO.ContactSelectAnySubjectHeading();
            automationPracticePO.ConctacSetConctacEmail("example@example.com");
            automationPracticePO.ConctacSetOrderReference("RF101");
            automationPracticePO.ContactAttachFile(@"C:\Users\JOTA\Desktop\Best man.pdf");
            automationPracticePO.ContactSetMessage(Message);
            automationPracticePO.ContactClickSendMessageButton();
            Assert.False(automationPracticePO.IsThereAContactFormError());
        }

        [Fact]
        public void ContactSendWithInvalidEmail()
        {
            automationPracticePO.GoToPage();
            automationPracticePO.GoToContactUsForm();
            automationPracticePO.ContactSelectAnySubjectHeading();
            automationPracticePO.ConctacSetConctacEmail("none");
            automationPracticePO.ConctacSetOrderReference("RF101");
            automationPracticePO.ContactAttachFile(@"C:\Users\JOTA\Desktop\Best man.pdf");
            automationPracticePO.ContactSetMessage(Message);
            automationPracticePO.ContactClickSendMessageButton();
            Assert.True(automationPracticePO.IsThereAContactFormError());
        }

        [Fact]
        public void SendWithoutSelectingSubjectHeading()
        {
            automationPracticePO.GoToPage();
            automationPracticePO.GoToContactUsForm();
            automationPracticePO.ConctacSetConctacEmail("example@example.com");
            automationPracticePO.ConctacSetOrderReference("RF101");
            automationPracticePO.ContactAttachFile(@"C:\Users\JOTA\Desktop\Best man.pdf");
            automationPracticePO.ContactSetMessage(Message);
            automationPracticePO.ContactClickSendMessageButton();
            Assert.True(automationPracticePO.IsThereAContactFormError());
        }

        [Fact]
        public void ContactSendWithoutEmail()
        {
            automationPracticePO.GoToPage();
            automationPracticePO.GoToContactUsForm();
            automationPracticePO.ContactSelectAnySubjectHeading();
            automationPracticePO.ConctacSetOrderReference("RF101");
            automationPracticePO.ContactAttachFile(@"C:\Users\JOTA\Desktop\Best man.pdf");
            automationPracticePO.ContactSetMessage(Message);
            automationPracticePO.ContactClickSendMessageButton();
            Assert.True(automationPracticePO.IsThereAContactFormError());
        }

        [Fact]
        public void ContactSendWithoutOrderReference()
        {
            automationPracticePO.GoToPage();
            automationPracticePO.GoToContactUsForm();
            automationPracticePO.ContactSelectAnySubjectHeading();
            automationPracticePO.ConctacSetConctacEmail("example@example.com");
            automationPracticePO.ContactAttachFile(@"C:\Users\JOTA\Desktop\Best man.pdf");
            automationPracticePO.ContactSetMessage(Message);
            automationPracticePO.ContactClickSendMessageButton();
            Assert.True(automationPracticePO.IsThereAContactFormError());
        }

        [Fact]
        public void ContactSendWithoutFile()
        {
            automationPracticePO.GoToPage();
            automationPracticePO.GoToContactUsForm();
            automationPracticePO.ContactSelectAnySubjectHeading();
            automationPracticePO.ConctacSetConctacEmail("example@example.com");
            automationPracticePO.ConctacSetOrderReference("RF101");
            automationPracticePO.ContactSetMessage(Message);
            automationPracticePO.ContactClickSendMessageButton();
            Assert.True(automationPracticePO.IsThereAContactFormError());
        }

        [Fact]
        public void ContactSendWithoutMessage()
        {
            automationPracticePO.GoToPage();
            automationPracticePO.GoToContactUsForm();
            automationPracticePO.ContactSelectAnySubjectHeading();
            automationPracticePO.ConctacSetConctacEmail("example@example.com");
            automationPracticePO.ConctacSetOrderReference("RF101");
            automationPracticePO.ContactAttachFile(@"C:\Users\JOTA\Desktop\Best man.pdf");
            automationPracticePO.ContactClickSendMessageButton();
            Assert.True(automationPracticePO.IsThereAContactFormError());
        }
    }
}
