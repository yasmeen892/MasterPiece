using UiPath.CodedWorkflows.DescriptorIntegration;

namespace TeacherApplicationReviewAutomation.ObjectRepository
{
    public static class Descriptors
    {
        public static class __Browser
        {
            static string _reference = "6AvHQZzA7k-1m7riz-x8jw/omA7hPVXAU29bzCrqskKFQ";
            public static _Implementation.___Browser.__Browser Browser { get; private set; } = new _Implementation.___Browser.__Browser();
        }

        public static class __Edge_ACME_System_1___Launch
        {
            static string _reference = "6AvHQZzA7k-1m7riz-x8jw/bJm-EFxCvkaw4Sl0QxpcNw";
            public static _Implementation.___Edge_ACME_System_1___Launch.__Edge_ACME_System_1___Launch Edge_ACME_System_1___Launch { get; private set; } = new _Implementation.___Edge_ACME_System_1___Launch.__Edge_ACME_System_1___Launch();
            public static _Implementation.___Edge_ACME_System_1___Launch.__Edge_ACME_System_1___Launch_1_ Edge_ACME_System_1___Launch_1_ { get; private set; } = new _Implementation.___Edge_ACME_System_1___Launch.__Edge_ACME_System_1___Launch_1_();
        }

        public static class __Edge_Aduca___Education_HTML_Template
        {
            static string _reference = "6AvHQZzA7k-1m7riz-x8jw/fNra4i9s4Eq7txLcZwIzAA";
            public static _Implementation.___Edge_Aduca___Education_HTML_Template.__Edge_Aduca___Education_HTML_Template Edge_Aduca___Education_HTML_Template { get; private set; } = new _Implementation.___Edge_Aduca___Education_HTML_Template.__Edge_Aduca___Education_HTML_Template();
        }
    }
}

namespace TeacherApplicationReviewAutomation._Implementation
{
    internal class ScreenDescriptorDefinition : IScreenDescriptorDefinition
    {
        public IScreenDescriptor Screen { get; set; }

        public string Reference { get; set; }

        public string DisplayName { get; set; }
    }

    internal class ElementDescriptorDefinition : IElementDescriptorDefinition
    {
        public IScreenDescriptor Screen { get; set; }

        public string Reference { get; set; }

        public string DisplayName { get; set; }

        public IElementDescriptor ParentElement { get; set; }

        public IElementDescriptor Element { get; set; }
    }

    namespace ___Browser
    {
        public class __Browser : IScreenDescriptor
        {
            public IScreenDescriptorDefinition GetDefinition()
            {
                return _screenDescriptor;
            }

            private readonly ScreenDescriptorDefinition _screenDescriptor;
            public __Browser()
            {
                _screenDescriptor = new ScreenDescriptorDefinition{Reference = "6AvHQZzA7k-1m7riz-x8jw/G7y0rRSZxkO_E5rYUo_gDg", DisplayName = "Browser", Screen = this};
            }
        }
    }

    namespace ___Edge_ACME_System_1___Launch._Edge_ACME_System_1___Launch
    {
        public class __Email : IElementDescriptor
        {
            private readonly IScreenDescriptor _screenDescriptor;
            private readonly IElementDescriptor _parentElementDescriptor;
            private readonly IElementDescriptorDefinition _elementDescriptor;
            public IElementDescriptorDefinition GetDefinition()
            {
                return _elementDescriptor;
            }

            public __Email(IScreenDescriptor screenDescriptor, IElementDescriptor parentElementDescriptor)
            {
                _screenDescriptor = screenDescriptor;
                _parentElementDescriptor = parentElementDescriptor;
                _elementDescriptor = new ElementDescriptorDefinition{Reference = "6AvHQZzA7k-1m7riz-x8jw/qzlnsI8bOEKDXMcA-cZDyg", DisplayName = "Email", Element = this, ParentElement = _parentElementDescriptor, Screen = screenDescriptor};
            }
        }
    }

    namespace ___Edge_ACME_System_1___Launch._Edge_ACME_System_1___Launch
    {
        public class __Login : IElementDescriptor
        {
            private readonly IScreenDescriptor _screenDescriptor;
            private readonly IElementDescriptor _parentElementDescriptor;
            private readonly IElementDescriptorDefinition _elementDescriptor;
            public IElementDescriptorDefinition GetDefinition()
            {
                return _elementDescriptor;
            }

            public __Login(IScreenDescriptor screenDescriptor, IElementDescriptor parentElementDescriptor)
            {
                _screenDescriptor = screenDescriptor;
                _parentElementDescriptor = parentElementDescriptor;
                _elementDescriptor = new ElementDescriptorDefinition{Reference = "6AvHQZzA7k-1m7riz-x8jw/gu-PuL9x2E-n7KTwjl3ypA", DisplayName = "Login", Element = this, ParentElement = _parentElementDescriptor, Screen = screenDescriptor};
            }
        }
    }

    namespace ___Edge_ACME_System_1___Launch._Edge_ACME_System_1___Launch
    {
        public class __Login_1_ : IElementDescriptor
        {
            private readonly IScreenDescriptor _screenDescriptor;
            private readonly IElementDescriptor _parentElementDescriptor;
            private readonly IElementDescriptorDefinition _elementDescriptor;
            public IElementDescriptorDefinition GetDefinition()
            {
                return _elementDescriptor;
            }

            public __Login_1_(IScreenDescriptor screenDescriptor, IElementDescriptor parentElementDescriptor)
            {
                _screenDescriptor = screenDescriptor;
                _parentElementDescriptor = parentElementDescriptor;
                _elementDescriptor = new ElementDescriptorDefinition{Reference = "6AvHQZzA7k-1m7riz-x8jw/CI-XVFLKDUufcEeyY3FNkA", DisplayName = "Login(1)", Element = this, ParentElement = _parentElementDescriptor, Screen = screenDescriptor};
            }
        }
    }

    namespace ___Edge_ACME_System_1___Launch._Edge_ACME_System_1___Launch
    {
        public class __Password : IElementDescriptor
        {
            private readonly IScreenDescriptor _screenDescriptor;
            private readonly IElementDescriptor _parentElementDescriptor;
            private readonly IElementDescriptorDefinition _elementDescriptor;
            public IElementDescriptorDefinition GetDefinition()
            {
                return _elementDescriptor;
            }

            public __Password(IScreenDescriptor screenDescriptor, IElementDescriptor parentElementDescriptor)
            {
                _screenDescriptor = screenDescriptor;
                _parentElementDescriptor = parentElementDescriptor;
                _elementDescriptor = new ElementDescriptorDefinition{Reference = "6AvHQZzA7k-1m7riz-x8jw/F0hstlkNvEGkrQGEN9U3Mg", DisplayName = "Password", Element = this, ParentElement = _parentElementDescriptor, Screen = screenDescriptor};
            }
        }
    }

    namespace ___Edge_ACME_System_1___Launch
    {
        public class __Edge_ACME_System_1___Launch : IScreenDescriptor
        {
            public IScreenDescriptorDefinition GetDefinition()
            {
                return _screenDescriptor;
            }

            private readonly ScreenDescriptorDefinition _screenDescriptor;
            public __Edge_ACME_System_1___Launch()
            {
                _screenDescriptor = new ScreenDescriptorDefinition{Reference = "6AvHQZzA7k-1m7riz-x8jw/p4x6Ka9DiUevJQdCV1tZ0g", DisplayName = "Edge ACME System 1 - Launch", Screen = this};
                Email = new _Implementation.___Edge_ACME_System_1___Launch._Edge_ACME_System_1___Launch.__Email(this, null);
                Login = new _Implementation.___Edge_ACME_System_1___Launch._Edge_ACME_System_1___Launch.__Login(this, null);
                Login_1_ = new _Implementation.___Edge_ACME_System_1___Launch._Edge_ACME_System_1___Launch.__Login_1_(this, null);
                Password = new _Implementation.___Edge_ACME_System_1___Launch._Edge_ACME_System_1___Launch.__Password(this, null);
            }

            public _Implementation.___Edge_ACME_System_1___Launch._Edge_ACME_System_1___Launch.__Email Email { get; private set; }

            public _Implementation.___Edge_ACME_System_1___Launch._Edge_ACME_System_1___Launch.__Login Login { get; private set; }

            public _Implementation.___Edge_ACME_System_1___Launch._Edge_ACME_System_1___Launch.__Login_1_ Login_1_ { get; private set; }

            public _Implementation.___Edge_ACME_System_1___Launch._Edge_ACME_System_1___Launch.__Password Password { get; private set; }
        }
    }

    namespace ___Edge_ACME_System_1___Launch._Edge_ACME_System_1___Launch_1_
    {
        public class __Extract_Table_Data : IElementDescriptor
        {
            private readonly IScreenDescriptor _screenDescriptor;
            private readonly IElementDescriptor _parentElementDescriptor;
            private readonly IElementDescriptorDefinition _elementDescriptor;
            public IElementDescriptorDefinition GetDefinition()
            {
                return _elementDescriptor;
            }

            public __Extract_Table_Data(IScreenDescriptor screenDescriptor, IElementDescriptor parentElementDescriptor)
            {
                _screenDescriptor = screenDescriptor;
                _parentElementDescriptor = parentElementDescriptor;
                _elementDescriptor = new ElementDescriptorDefinition{Reference = "6AvHQZzA7k-1m7riz-x8jw/TH8GeycidEenN9jb14VpaQ", DisplayName = "Extract Table Data", Element = this, ParentElement = _parentElementDescriptor, Screen = screenDescriptor};
            }
        }
    }

    namespace ___Edge_ACME_System_1___Launch._Edge_ACME_System_1___Launch_1_
    {
        public class __Teacher_Request : IElementDescriptor
        {
            private readonly IScreenDescriptor _screenDescriptor;
            private readonly IElementDescriptor _parentElementDescriptor;
            private readonly IElementDescriptorDefinition _elementDescriptor;
            public IElementDescriptorDefinition GetDefinition()
            {
                return _elementDescriptor;
            }

            public __Teacher_Request(IScreenDescriptor screenDescriptor, IElementDescriptor parentElementDescriptor)
            {
                _screenDescriptor = screenDescriptor;
                _parentElementDescriptor = parentElementDescriptor;
                _elementDescriptor = new ElementDescriptorDefinition{Reference = "6AvHQZzA7k-1m7riz-x8jw/39uspIumIkymnBeX6ydvqg", DisplayName = "Teacher Request", Element = this, ParentElement = _parentElementDescriptor, Screen = screenDescriptor};
            }
        }
    }

    namespace ___Edge_ACME_System_1___Launch
    {
        public class __Edge_ACME_System_1___Launch_1_ : IScreenDescriptor
        {
            public IScreenDescriptorDefinition GetDefinition()
            {
                return _screenDescriptor;
            }

            private readonly ScreenDescriptorDefinition _screenDescriptor;
            public __Edge_ACME_System_1___Launch_1_()
            {
                _screenDescriptor = new ScreenDescriptorDefinition{Reference = "6AvHQZzA7k-1m7riz-x8jw/zw0wWenfcUSZyI79REBUNA", DisplayName = "Edge ACME System 1 - Launch(1)", Screen = this};
                Extract_Table_Data = new _Implementation.___Edge_ACME_System_1___Launch._Edge_ACME_System_1___Launch_1_.__Extract_Table_Data(this, null);
                Teacher_Request = new _Implementation.___Edge_ACME_System_1___Launch._Edge_ACME_System_1___Launch_1_.__Teacher_Request(this, null);
            }

            public _Implementation.___Edge_ACME_System_1___Launch._Edge_ACME_System_1___Launch_1_.__Extract_Table_Data Extract_Table_Data { get; private set; }

            public _Implementation.___Edge_ACME_System_1___Launch._Edge_ACME_System_1___Launch_1_.__Teacher_Request Teacher_Request { get; private set; }
        }
    }

    namespace ___Edge_Aduca___Education_HTML_Template
    {
        public class __Edge_Aduca___Education_HTML_Template : IScreenDescriptor
        {
            public IScreenDescriptorDefinition GetDefinition()
            {
                return _screenDescriptor;
            }

            private readonly ScreenDescriptorDefinition _screenDescriptor;
            public __Edge_Aduca___Education_HTML_Template()
            {
                _screenDescriptor = new ScreenDescriptorDefinition{Reference = "6AvHQZzA7k-1m7riz-x8jw/GUwUnZWyAE2hWfw_ofkzig", DisplayName = "Edge Aduca - Education HTML Template", Screen = this};
            }
        }
    }
}