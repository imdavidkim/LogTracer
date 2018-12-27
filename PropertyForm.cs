using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace Tracer
{
    //public interface IPropertyForm
    //{
    //    PropertyForm prop { get; set; }
    //}
    public partial class PropertyForm : Form //, IPropertyForm
    {
        private List<FilteringInfo> filteringList;
        public class FilteringInfo
        {
            public string pattern;
            public Color bgcolor;
            public Color fgcolor;
            public bool alert;
            public int count;
            public FilteringInfo(string s, Color c1, Color c2, bool b)
            {
                pattern = s;
                bgcolor = c1;
                fgcolor = c2;
                alert = b;
                count = 0;
            }
        }

        private List<ContactInfo> contactList;
        public class ContactInfo
        {
            public string name;
            public string id;
            public string cellphone;

            public ContactInfo(string n, string i, string c)
            {
                name = n;
                id = i;
                cellphone = c;
            }
        }
        private SettingInfo Info;
        public SettingInfo _Info
        {
            get
            {
                return Info;
            }

            set
            {
                Info = value;
            }
        }

        public List<FilteringInfo> FilteringList
        {
            get
            {
                return filteringList;
            }

            set
            {
                filteringList = value;
            }
        }

        public List<ContactInfo> ContactList
        {
            get
            {
                return contactList;
            }

            set
            {
                contactList = value;
            }
        }

        public class SettingInfo
        {
            private string _pattern01_string;
            private Color _pattern01_bgcolor;
            private Color _pattern01_fgcolor;

            private string _pattern02_string;
            private Color _pattern02_bgcolor;
            private Color _pattern02_fgcolor;

            private string _pattern03_string;
            private Color _pattern03_bgcolor;
            private Color _pattern03_fgcolor;

            private string _pattern04_string;
            private Color _pattern04_bgcolor;
            private Color _pattern04_fgcolor;

            private string _pattern05_string;
            private Color _pattern05_bgcolor;
            private Color _pattern05_fgcolor;

            private string _pattern06_string;
            private Color _pattern06_bgcolor;
            private Color _pattern06_fgcolor;

            private string _pattern07_string;
            private Color _pattern07_bgcolor;
            private Color _pattern07_fgcolor;

            private string _pattern08_string;
            private Color _pattern08_bgcolor;
            private Color _pattern08_fgcolor;

            private string _pattern09_string;
            private Color _pattern09_bgcolor;
            private Color _pattern09_fgcolor;

            private string _pattern10_string;
            private Color _pattern10_bgcolor;
            private Color _pattern10_fgcolor;

            private string _pattern11_string;
            private Color _pattern11_bgcolor;
            private Color _pattern11_fgcolor;

            private string _pattern12_string;
            private Color _pattern12_bgcolor;
            private Color _pattern12_fgcolor;

            private string _pattern13_string;
            private Color _pattern13_bgcolor;
            private Color _pattern13_fgcolor;

            private string _pattern14_string;
            private Color _pattern14_bgcolor;
            private Color _pattern14_fgcolor;

            private string _pattern15_string;
            private Color _pattern15_bgcolor;
            private Color _pattern15_fgcolor;

            private string _pattern16_string;
            private Color _pattern16_bgcolor;
            private Color _pattern16_fgcolor;

            private string _pattern17_string;
            private Color _pattern17_bgcolor;
            private Color _pattern17_fgcolor;

            private string _pattern18_string;
            private Color _pattern18_bgcolor;
            private Color _pattern18_fgcolor;

            private string _pattern19_string;
            private Color _pattern19_bgcolor;
            private Color _pattern19_fgcolor;

            private string _pattern20_string;
            private Color _pattern20_bgcolor;
            private Color _pattern20_fgcolor;

            private bool _pattern01_alert;
            private bool _pattern02_alert;
            private bool _pattern03_alert;
            private bool _pattern04_alert;
            private bool _pattern05_alert;
            private bool _pattern06_alert;
            private bool _pattern07_alert;
            private bool _pattern08_alert;
            private bool _pattern09_alert;
            private bool _pattern10_alert;
            private bool _pattern11_alert;
            private bool _pattern12_alert;
            private bool _pattern13_alert;
            private bool _pattern14_alert;
            private bool _pattern15_alert;
            private bool _pattern16_alert;
            private bool _pattern17_alert;
            private bool _pattern18_alert;
            private bool _pattern19_alert;
            private bool _pattern20_alert;


            private string _receiver01_name;
            private string _receiver01_id;
            private string _receiver01_cell;

            private string _receiver02_name;
            private string _receiver02_id;
            private string _receiver02_cell;

            private string _receiver03_name;
            private string _receiver03_id;
            private string _receiver03_cell;

            private string _receiver04_name;
            private string _receiver04_id;
            private string _receiver04_cell;

            private string _receiver05_name;
            private string _receiver05_id;
            private string _receiver05_cell;

            private string _receiver06_name;
            private string _receiver06_id;
            private string _receiver06_cell;

            private string _receiver07_name;
            private string _receiver07_id;
            private string _receiver07_cell;

            private string _receiver08_name;
            private string _receiver08_id;
            private string _receiver08_cell;

            private string _receiver09_name;
            private string _receiver09_id;
            private string _receiver09_cell;

            private string _receiver10_name;
            private string _receiver10_id;
            private string _receiver10_cell;

            private string _receiver11_name;
            private string _receiver11_id;
            private string _receiver11_cell;

            private string _receiver12_name;
            private string _receiver12_id;
            private string _receiver12_cell;

            private string _receiver13_name;
            private string _receiver13_id;
            private string _receiver13_cell;

            private string _receiver14_name;
            private string _receiver14_id;
            private string _receiver14_cell;

            private string _receiver15_name;
            private string _receiver15_id;
            private string _receiver15_cell;

            [CategoryAttribute("Pattern 01"),
            DescriptionAttribute("Patterns to Find out"),]
            public string Pattern01_string
            {
                get
                {
                    return _pattern01_string;
                }

                set
                {
                    _pattern01_string = value;
                }
            }
            [CategoryAttribute("Pattern 01"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern01_bgcolor
            {
                get
                {
                    return _pattern01_bgcolor;
                }

                set
                {
                    _pattern01_bgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 01"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern01_fgcolor
            {
                get
                {
                    return _pattern01_fgcolor;
                }

                set
                {
                    _pattern01_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 02"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern02_string
            {
                get
                {
                    return _pattern02_string;
                }

                set
                {
                    _pattern02_string = value;
                }
            }
            [CategoryAttribute("Pattern 02"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern02_bgcolor
            {
                get
                {
                    return _pattern02_bgcolor;
                }

                set
                {
                    _pattern02_bgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 02"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern02_fgcolor
            {
                get
                {
                    return _pattern02_fgcolor;
                }

                set
                {
                    _pattern02_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 03"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern03_string
            {
                get
                {
                    return _pattern03_string;
                }

                set
                {
                    _pattern03_string = value;
                }
            }
            [CategoryAttribute("Pattern 03"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern03_bgcolor
            {
                get
                {
                    return _pattern03_bgcolor;
                }

                set
                {
                    _pattern03_bgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 03"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern03_fgcolor
            {
                get
                {
                    return _pattern03_fgcolor;
                }

                set
                {
                    _pattern03_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 04"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern04_string
            {
                get
                {
                    return _pattern04_string;
                }

                set
                {
                    _pattern04_string = value;
                }
            }
            [CategoryAttribute("Pattern 04"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern04_bgcolor
            {
                get
                {
                    return _pattern04_bgcolor;
                }

                set
                {
                    _pattern04_bgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 04"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern04_fgcolor
            {
                get
                {
                    return _pattern04_fgcolor;
                }

                set
                {
                    _pattern04_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 05"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern05_string
            {
                get
                {
                    return _pattern05_string;
                }

                set
                {
                    _pattern05_string = value;
                }
            }
            [CategoryAttribute("Pattern 05"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern05_bgcolor
            {
                get
                {
                    return _pattern05_bgcolor;
                }

                set
                {
                    _pattern05_bgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 05"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern05_fgcolor
            {
                get
                {
                    return _pattern05_fgcolor;
                }

                set
                {
                    _pattern05_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 06"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern06_string
            {
                get
                {
                    return _pattern06_string;
                }

                set
                {
                    _pattern06_string = value;
                }
            }
            [CategoryAttribute("Pattern 06"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern06_bgcolor
            {
                get
                {
                    return _pattern06_bgcolor;
                }

                set
                {
                    _pattern06_bgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 06"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern06_fgcolor
            {
                get
                {
                    return _pattern06_fgcolor;
                }

                set
                {
                    _pattern06_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 07"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern07_string
            {
                get
                {
                    return _pattern07_string;
                }

                set
                {
                    _pattern07_string = value;
                }
            }
            [CategoryAttribute("Pattern 07"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern07_bgcolor
            {
                get
                {
                    return _pattern07_bgcolor;
                }

                set
                {
                    _pattern07_bgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 07"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern07_fgcolor
            {
                get
                {
                    return _pattern07_fgcolor;
                }

                set
                {
                    _pattern07_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 08"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern08_string
            {
                get
                {
                    return _pattern08_string;
                }

                set
                {
                    _pattern08_string = value;
                }
            }
            [CategoryAttribute("Pattern 08"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern08_bgcolor
            {
                get
                {
                    return _pattern08_bgcolor;
                }

                set
                {
                    _pattern08_bgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 08"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern08_fgcolor
            {
                get
                {
                    return _pattern08_fgcolor;
                }

                set
                {
                    _pattern08_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 09"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern09_string
            {
                get
                {
                    return _pattern09_string;
                }

                set
                {
                    _pattern09_string = value;
                }
            }
            [CategoryAttribute("Pattern 09"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern09_bgcolor
            {
                get
                {
                    return _pattern09_bgcolor;
                }

                set
                {
                    _pattern09_bgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 09"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern09_fgcolor
            {
                get
                {
                    return _pattern09_fgcolor;
                }

                set
                {
                    _pattern09_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 10"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern10_string
            {
                get
                {
                    return _pattern10_string;
                }

                set
                {
                    _pattern10_string = value;
                }
            }
            [CategoryAttribute("Pattern 10"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern10_bgcolor
            {
                get
                {
                    return _pattern10_bgcolor;
                }

                set
                {
                    _pattern10_bgcolor = value;
                }
            }

            [CategoryAttribute("Pattern 10"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern10_fgcolor
            {
                get
                {
                    return _pattern10_fgcolor;
                }

                set
                {
                    _pattern10_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 11"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern11_string
            {
                get
                {
                    return _pattern11_string;
                }

                set
                {
                    _pattern11_string = value;
                }
            }
            [CategoryAttribute("Pattern 11"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern11_bgcolor
            {
                get
                {
                    return _pattern11_bgcolor;
                }

                set
                {
                    _pattern11_bgcolor = value;
                }
            }

            [CategoryAttribute("Pattern 11"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern11_fgcolor
            {
                get
                {
                    return _pattern11_fgcolor;
                }

                set
                {
                    _pattern11_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 12"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern12_string
            {
                get
                {
                    return _pattern12_string;
                }

                set
                {
                    _pattern12_string = value;
                }
            }
            [CategoryAttribute("Pattern 12"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern12_bgcolor
            {
                get
                {
                    return _pattern12_bgcolor;
                }

                set
                {
                    _pattern12_bgcolor = value;
                }
            }

            [CategoryAttribute("Pattern 12"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern12_fgcolor
            {
                get
                {
                    return _pattern12_fgcolor;
                }

                set
                {
                    _pattern12_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 13"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern13_string
            {
                get
                {
                    return _pattern13_string;
                }

                set
                {
                    _pattern13_string = value;
                }
            }
            [CategoryAttribute("Pattern 13"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern13_bgcolor
            {
                get
                {
                    return _pattern13_bgcolor;
                }

                set
                {
                    _pattern13_bgcolor = value;
                }
            }

            [CategoryAttribute("Pattern 13"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern13_fgcolor
            {
                get
                {
                    return _pattern13_fgcolor;
                }

                set
                {
                    _pattern13_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 14"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern14_string
            {
                get
                {
                    return _pattern14_string;
                }

                set
                {
                    _pattern14_string = value;
                }
            }
            [CategoryAttribute("Pattern 14"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern14_bgcolor
            {
                get
                {
                    return _pattern14_bgcolor;
                }

                set
                {
                    _pattern14_bgcolor = value;
                }
            }

            [CategoryAttribute("Pattern 14"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern14_fgcolor
            {
                get
                {
                    return _pattern14_fgcolor;
                }

                set
                {
                    _pattern14_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 15"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern15_string
            {
                get
                {
                    return _pattern15_string;
                }

                set
                {
                    _pattern15_string = value;
                }
            }
            [CategoryAttribute("Pattern 15"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern15_bgcolor
            {
                get
                {
                    return _pattern15_bgcolor;
                }

                set
                {
                    _pattern15_bgcolor = value;
                }
            }

            [CategoryAttribute("Pattern 15"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern15_fgcolor
            {
                get
                {
                    return _pattern15_fgcolor;
                }

                set
                {
                    _pattern15_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 16"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern16_string
            {
                get
                {
                    return _pattern16_string;
                }

                set
                {
                    _pattern16_string = value;
                }
            }
            [CategoryAttribute("Pattern 16"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern16_bgcolor
            {
                get
                {
                    return _pattern16_bgcolor;
                }

                set
                {
                    _pattern16_bgcolor = value;
                }
            }

            [CategoryAttribute("Pattern 16"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern16_fgcolor
            {
                get
                {
                    return _pattern16_fgcolor;
                }

                set
                {
                    _pattern16_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 17"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern17_string
            {
                get
                {
                    return _pattern17_string;
                }

                set
                {
                    _pattern17_string = value;
                }
            }
            [CategoryAttribute("Pattern 17"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern17_bgcolor
            {
                get
                {
                    return _pattern17_bgcolor;
                }

                set
                {
                    _pattern17_bgcolor = value;
                }
            }

            [CategoryAttribute("Pattern 17"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern17_fgcolor
            {
                get
                {
                    return _pattern17_fgcolor;
                }

                set
                {
                    _pattern17_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 18"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern18_string
            {
                get
                {
                    return _pattern18_string;
                }

                set
                {
                    _pattern18_string = value;
                }
            }
            [CategoryAttribute("Pattern 18"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern18_bgcolor
            {
                get
                {
                    return _pattern18_bgcolor;
                }

                set
                {
                    _pattern18_bgcolor = value;
                }
            }

            [CategoryAttribute("Pattern 18"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern18_fgcolor
            {
                get
                {
                    return _pattern18_fgcolor;
                }

                set
                {
                    _pattern18_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 19"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern19_string
            {
                get
                {
                    return _pattern19_string;
                }

                set
                {
                    _pattern19_string = value;
                }
            }
            [CategoryAttribute("Pattern 19"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern19_bgcolor
            {
                get
                {
                    return _pattern19_bgcolor;
                }

                set
                {
                    _pattern19_bgcolor = value;
                }
            }

            [CategoryAttribute("Pattern 19"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern19_fgcolor
            {
                get
                {
                    return _pattern19_fgcolor;
                }

                set
                {
                    _pattern19_fgcolor = value;
                }
            }
            [CategoryAttribute("Pattern 20"),
            DescriptionAttribute("Patterns to Find out")]
            public string Pattern20_string
            {
                get
                {
                    return _pattern20_string;
                }

                set
                {
                    _pattern20_string = value;
                }
            }
            [CategoryAttribute("Pattern 20"),
            DescriptionAttribute("Applying BackGroundColor for matched pattern")]
            public Color Pattern20_bgcolor
            {
                get
                {
                    return _pattern20_bgcolor;
                }

                set
                {
                    _pattern20_bgcolor = value;
                }
            }

            [CategoryAttribute("Pattern 20"),
            DescriptionAttribute("Applying ForeGroundColor for matched pattern")]
            public Color Pattern20_fgcolor
            {
                get
                {
                    return _pattern20_fgcolor;
                }

                set
                {
                    _pattern20_fgcolor = value;
                }
            }
            [CategoryAttribute("Receiver 01"),
            DescriptionAttribute("Name of Contact Information for sending messages")]
            public string Receiver01_name
            {
                get
                {
                    return _receiver01_name;
                }

                set
                {
                    _receiver01_name = value;
                }
            }
            [CategoryAttribute("Receiver 01"),
            DescriptionAttribute("ID of Contact Information for sending messages")]
            public string Receiver01_id
            {
                get
                {
                    return _receiver01_id;
                }

                set
                {
                    _receiver01_id = value;
                }
            }
            [CategoryAttribute("Receiver 01"),
            DescriptionAttribute("CellPhone of Contact Information for sending messages")]
            public string Receiver01_cell
            {
                get
                {
                    return _receiver01_cell;
                }

                set
                {
                    _receiver01_cell = value;
                }
            }
            [CategoryAttribute("Receiver 02"),
            DescriptionAttribute("Name of Contact Information for sending messages")]
            public string Receiver02_name
            {
                get
                {
                    return _receiver02_name;
                }

                set
                {
                    _receiver02_name = value;
                }
            }
            [CategoryAttribute("Receiver 02"),
            DescriptionAttribute("ID of Contact Information for sending messages")]
            public string Receiver02_id
            {
                get
                {
                    return _receiver02_id;
                }

                set
                {
                    _receiver02_id = value;
                }
            }
            [CategoryAttribute("Receiver 02"),
            DescriptionAttribute("CellPhone of Contact Information for sending messages")]
            public string Receiver02_cell
            {
                get
                {
                    return _receiver02_cell;
                }

                set
                {
                    _receiver02_cell = value;
                }
            }
            [CategoryAttribute("Receiver 03"),
            DescriptionAttribute("Name of Contact Information for sending messages")]
            public string Receiver03_name
            {
                get
                {
                    return _receiver03_name;
                }

                set
                {
                    _receiver03_name = value;
                }
            }
            [CategoryAttribute("Receiver 03"),
            DescriptionAttribute("ID of Contact Information for sending messages")]
            public string Receiver03_id
            {
                get
                {
                    return _receiver03_id;
                }

                set
                {
                    _receiver03_id = value;
                }
            }
            [CategoryAttribute("Receiver 03"),
            DescriptionAttribute("CellPhone of Contact Information for sending messages")]
            public string Receiver03_cell
            {
                get
                {
                    return _receiver03_cell;
                }

                set
                {
                    _receiver03_cell = value;
                }
            }
            [CategoryAttribute("Receiver 04"),
            DescriptionAttribute("Name of Contact Information for sending messages")]
            public string Receiver04_name
            {
                get
                {
                    return _receiver04_name;
                }

                set
                {
                    _receiver04_name = value;
                }
            }
            [CategoryAttribute("Receiver 04"),
            DescriptionAttribute("ID of Contact Information for sending messages")]
            public string Receiver04_id
            {
                get
                {
                    return _receiver04_id;
                }

                set
                {
                    _receiver04_id = value;
                }
            }
            [CategoryAttribute("Receiver 04"),
            DescriptionAttribute("CellPhone of Contact Information for sending messages")]
            public string Receiver04_cell
            {
                get
                {
                    return _receiver04_cell;
                }

                set
                {
                    _receiver04_cell = value;
                }
            }
            [CategoryAttribute("Receiver 05"),
            DescriptionAttribute("Name of Contact Information for sending messages")]
            public string Receiver05_name
            {
                get
                {
                    return _receiver05_name;
                }

                set
                {
                    _receiver05_name = value;
                }
            }
            [CategoryAttribute("Receiver 05"),
            DescriptionAttribute("ID of Contact Information for sending messages")]
            public string Receiver05_id
            {
                get
                {
                    return _receiver05_id;
                }

                set
                {
                    _receiver05_id = value;
                }
            }
            [CategoryAttribute("Receiver 05"),
            DescriptionAttribute("CellPhone of Contact Information for sending messages")]
            public string Receiver05_cell
            {
                get
                {
                    return _receiver05_cell;
                }

                set
                {
                    _receiver05_cell = value;
                }
            }
            [CategoryAttribute("Receiver 06"),
            DescriptionAttribute("Name of Contact Information for sending messages")]
            public string Receiver06_name
            {
                get
                {
                    return _receiver06_name;
                }

                set
                {
                    _receiver06_name = value;
                }
            }
            [CategoryAttribute("Receiver 06"),
            DescriptionAttribute("ID of Contact Information for sending messages")]
            public string Receiver06_id
            {
                get
                {
                    return _receiver06_id;
                }

                set
                {
                    _receiver06_id = value;
                }
            }
            [CategoryAttribute("Receiver 06"),
            DescriptionAttribute("CellPhone of Contact Information for sending messages")]
            public string Receiver06_cell
            {
                get
                {
                    return _receiver06_cell;
                }

                set
                {
                    _receiver06_cell = value;
                }
            }
            [CategoryAttribute("Receiver 07"),
            DescriptionAttribute("Name of Contact Information for sending messages")]
            public string Receiver07_name
            {
                get
                {
                    return _receiver07_name;
                }

                set
                {
                    _receiver07_name = value;
                }
            }
            [CategoryAttribute("Receiver 07"),
            DescriptionAttribute("ID of Contact Information for sending messages")]
            public string Receiver07_id
            {
                get
                {
                    return _receiver07_id;
                }

                set
                {
                    _receiver07_id = value;
                }
            }
            [CategoryAttribute("Receiver 07"),
            DescriptionAttribute("CellPhone of Contact Information for sending messages")]
            public string Receiver07_cell
            {
                get
                {
                    return _receiver07_cell;
                }

                set
                {
                    _receiver07_cell = value;
                }
            }
            [CategoryAttribute("Receiver 08"),
            DescriptionAttribute("Name of Contact Information for sending messages")]
            public string Receiver08_name
            {
                get
                {
                    return _receiver08_name;
                }

                set
                {
                    _receiver08_name = value;
                }
            }
            [CategoryAttribute("Receiver 08"),
            DescriptionAttribute("ID of Contact Information for sending messages")]
            public string Receiver08_id
            {
                get
                {
                    return _receiver08_id;
                }

                set
                {
                    _receiver08_id = value;
                }
            }
            [CategoryAttribute("Receiver 08"),
            DescriptionAttribute("CellPhone of Contact Information for sending messages")]
            public string Receiver08_cell
            {
                get
                {
                    return _receiver08_cell;
                }

                set
                {
                    _receiver08_cell = value;
                }
            }
            [CategoryAttribute("Receiver 09"),
            DescriptionAttribute("Name of Contact Information for sending messages")]
            public string Receiver09_name
            {
                get
                {
                    return _receiver09_name;
                }

                set
                {
                    _receiver09_name = value;
                }
            }
            [CategoryAttribute("Receiver 09"),
            DescriptionAttribute("ID of Contact Information for sending messages")]
            public string Receiver09_id
            {
                get
                {
                    return _receiver09_id;
                }

                set
                {
                    _receiver09_id = value;
                }
            }
            [CategoryAttribute("Receiver 09"),
            DescriptionAttribute("CellPhone of Contact Information for sending messages")]
            public string Receiver09_cell
            {
                get
                {
                    return _receiver09_cell;
                }

                set
                {
                    _receiver09_cell = value;
                }
            }
            [CategoryAttribute("Receiver 10"),
            DescriptionAttribute("Name of Contact Information for sending messages")]
            public string Receiver10_name
            {
                get
                {
                    return _receiver10_name;
                }

                set
                {
                    _receiver10_name = value;
                }
            }
            [CategoryAttribute("Receiver 10"),
            DescriptionAttribute("ID of Contact Information for sending messages")]
            public string Receiver10_id
            {
                get
                {
                    return _receiver10_id;
                }

                set
                {
                    _receiver10_id = value;
                }
            }
            [CategoryAttribute("Receiver 10"),
            DescriptionAttribute("CellPhone of Contact Information for sending messages")]
            public string Receiver10_cell
            {
                get
                {
                    return _receiver10_cell;
                }

                set
                {
                    _receiver10_cell = value;
                }
            }
            [CategoryAttribute("Receiver 11"),
            DescriptionAttribute("Name of Contact Information for sending messages")]
            public string Receiver11_name
            {
                get
                {
                    return _receiver11_name;
                }

                set
                {
                    _receiver11_name = value;
                }
            }
            [CategoryAttribute("Receiver 11"),
            DescriptionAttribute("ID of Contact Information for sending messages")]
            public string Receiver11_id
            {
                get
                {
                    return _receiver11_id;
                }

                set
                {
                    _receiver11_id = value;
                }
            }
            [CategoryAttribute("Receiver 11"),
            DescriptionAttribute("CellPhone of Contact Information for sending messages")]
            public string Receiver11_cell
            {
                get
                {
                    return _receiver11_cell;
                }

                set
                {
                    _receiver11_cell = value;
                }
            }
            [CategoryAttribute("Receiver 12"),
            DescriptionAttribute("Name of Contact Information for sending messages")]
            public string Receiver12_name
            {
                get
                {
                    return _receiver12_name;
                }

                set
                {
                    _receiver12_name = value;
                }
            }
            [CategoryAttribute("Receiver 12"),
            DescriptionAttribute("ID of Contact Information for sending messages")]
            public string Receiver12_id
            {
                get
                {
                    return _receiver12_id;
                }

                set
                {
                    _receiver12_id = value;
                }
            }
            [CategoryAttribute("Receiver 12"),
            DescriptionAttribute("CellPhone of Contact Information for sending messages")]
            public string Receiver12_cell
            {
                get
                {
                    return _receiver12_cell;
                }

                set
                {
                    _receiver12_cell = value;
                }
            }
            [CategoryAttribute("Receiver 13"),
            DescriptionAttribute("Name of Contact Information for sending messages")]
            public string Receiver13_name
            {
                get
                {
                    return _receiver13_name;
                }

                set
                {
                    _receiver13_name = value;
                }
            }
            [CategoryAttribute("Receiver 13"),
            DescriptionAttribute("ID of Contact Information for sending messages")]
            public string Receiver13_id
            {
                get
                {
                    return _receiver13_id;
                }

                set
                {
                    _receiver13_id = value;
                }
            }
            [CategoryAttribute("Receiver 13"),
            DescriptionAttribute("CellPhone of Contact Information for sending messages")]
            public string Receiver13_cell
            {
                get
                {
                    return _receiver13_cell;
                }

                set
                {
                    _receiver13_cell = value;
                }
            }
            [CategoryAttribute("Receiver 14"),
            DescriptionAttribute("Name of Contact Information for sending messages")]
            public string Receiver14_name
            {
                get
                {
                    return _receiver14_name;
                }

                set
                {
                    _receiver14_name = value;
                }
            }
            [CategoryAttribute("Receiver 14"),
            DescriptionAttribute("ID of Contact Information for sending messages")]
            public string Receiver14_id
            {
                get
                {
                    return _receiver14_id;
                }

                set
                {
                    _receiver14_id = value;
                }
            }
            [CategoryAttribute("Receiver 14"),
            DescriptionAttribute("CellPhone of Contact Information for sending messages")]
            public string Receiver14_cell
            {
                get
                {
                    return _receiver14_cell;
                }

                set
                {
                    _receiver14_cell = value;
                }
            }
            [CategoryAttribute("Receiver 15"),
            DescriptionAttribute("Name of Contact Information for sending messages")]
            public string Receiver15_name
            {
                get
                {
                    return _receiver15_name;
                }

                set
                {
                    _receiver15_name = value;
                }
            }
            [CategoryAttribute("Receiver 15"),
            DescriptionAttribute("ID of Contact Information for sending messages")]
            public string Receiver15_id
            {
                get
                {
                    return _receiver15_id;
                }

                set
                {
                    _receiver15_id = value;
                }
            }
            [CategoryAttribute("Receiver 15"),
            DescriptionAttribute("CellPhone of Contact Information for sending messages")]
            public string Receiver15_cell
            {
                get
                {
                    return _receiver15_cell;
                }

                set
                {
                    _receiver15_cell = value;
                }
            }
            [CategoryAttribute("Pattern 01"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern01_alert
            {
                get
                {
                    return _pattern01_alert;
                }

                set
                {
                    _pattern01_alert = value;
                }
            }
            [CategoryAttribute("Pattern 02"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern02_alert
            {
                get
                {
                    return _pattern02_alert;
                }

                set
                {
                    _pattern02_alert = value;
                }
            }
            [CategoryAttribute("Pattern 03"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern03_alert
            {
                get
                {
                    return _pattern03_alert;
                }

                set
                {
                    _pattern03_alert = value;
                }
            }
            [CategoryAttribute("Pattern 04"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern04_alert
            {
                get
                {
                    return _pattern04_alert;
                }

                set
                {
                    _pattern04_alert = value;
                }
            }
            [CategoryAttribute("Pattern 05"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern05_alert
            {
                get
                {
                    return _pattern05_alert;
                }

                set
                {
                    _pattern05_alert = value;
                }
            }
            [CategoryAttribute("Pattern 06"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern06_alert
            {
                get
                {
                    return _pattern06_alert;
                }

                set
                {
                    _pattern06_alert = value;
                }
            }
            [CategoryAttribute("Pattern 07"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern07_alert
            {
                get
                {
                    return _pattern07_alert;
                }

                set
                {
                    _pattern07_alert = value;
                }
            }
            [CategoryAttribute("Pattern 08"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern08_alert
            {
                get
                {
                    return _pattern08_alert;
                }

                set
                {
                    _pattern08_alert = value;
                }
            }
            [CategoryAttribute("Pattern 09"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern09_alert
            {
                get
                {
                    return _pattern09_alert;
                }

                set
                {
                    _pattern09_alert = value;
                }
            }
            [CategoryAttribute("Pattern 10"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern10_alert
            {
                get
                {
                    return _pattern10_alert;
                }

                set
                {
                    _pattern10_alert = value;
                }
            }
            [CategoryAttribute("Pattern 11"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern11_alert
            {
                get
                {
                    return _pattern11_alert;
                }

                set
                {
                    _pattern11_alert = value;
                }
            }
            [CategoryAttribute("Pattern 12"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern12_alert
            {
                get
                {
                    return _pattern12_alert;
                }

                set
                {
                    _pattern12_alert = value;
                }
            }
            [CategoryAttribute("Pattern 13"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern13_alert
            {
                get
                {
                    return _pattern13_alert;
                }

                set
                {
                    _pattern13_alert = value;
                }
            }
            [CategoryAttribute("Pattern 14"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern14_alert
            {
                get
                {
                    return _pattern14_alert;
                }

                set
                {
                    _pattern14_alert = value;
                }
            }
            [CategoryAttribute("Pattern 15"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern15_alert
            {
                get
                {
                    return _pattern15_alert;
                }

                set
                {
                    _pattern15_alert = value;
                }
            }
            [CategoryAttribute("Pattern 16"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern16_alert
            {
                get
                {
                    return _pattern16_alert;
                }

                set
                {
                    _pattern16_alert = value;
                }
            }
            [CategoryAttribute("Pattern 17"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern17_alert
            {
                get
                {
                    return _pattern17_alert;
                }

                set
                {
                    _pattern17_alert = value;
                }
            }
            [CategoryAttribute("Pattern 18"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern18_alert
            {
                get
                {
                    return _pattern18_alert;
                }

                set
                {
                    _pattern18_alert = value;
                }
            }
            [CategoryAttribute("Pattern 19"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern19_alert
            {
                get
                {
                    return _pattern19_alert;
                }

                set
                {
                    _pattern19_alert = value;
                }
            }
            [CategoryAttribute("Pattern 20"),
            DescriptionAttribute("Sending message Alert Flag")]
            public bool Pattern20_alert
            {
                get
                {
                    return _pattern20_alert;
                }

                set
                {
                    _pattern20_alert = value;
                }
            }
        }
        public PropertyForm()
        {
            InitializeComponent();
            Initializing();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            string check = string.Empty;
            try
            {
                var appSetting = ConfigurationManager.AppSettings;
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                List<string> patternsSettingString = getSettingsName("Pattern", 20);
                List<string> contactsSettingString = getSettingsName("ContactInfo", 15);

                List<string> patternsSettingStringValue = getSettingsNameWithPostfix("Pattern", "_string", 20);
                List<string> patternsSettingBgColorValue = getSettingsNameWithPostfix("Pattern", "_bgcolor", 20);
                List<string> patternsSettingFgColorValue = getSettingsNameWithPostfix("Pattern", "_fgcolor", 20);
                List<string> patternsSettingAlertValue = getSettingsNameWithPostfix("Pattern", "_alert", 20);
                List<string> contactsSettingCellPhoneValue = getSettingsNameWithPostfix("Receiver", "_cell", 15);
                List<string> contactsSettingIDValue = getSettingsNameWithPostfix("Receiver", "_id", 15);
                List<string> contactsSettingNameValue = getSettingsNameWithPostfix("Receiver", "_name", 15);
                for (int i = 1; i <= patternsSettingString.Count; i++)
                {
                    check = "savePatternsSettingString" + i.ToString();
                    
                    var tmp1 = typeof(SettingInfo).GetProperty(patternsSettingStringValue[i - 1]);
                    var tmp2 = typeof(SettingInfo).GetProperty(patternsSettingBgColorValue[i - 1]);
                    var tmp3 = typeof(SettingInfo).GetProperty(patternsSettingFgColorValue[i - 1]);
                    var tmp4 = typeof(SettingInfo).GetProperty(patternsSettingAlertValue[i - 1]);
                    config.AppSettings.Settings[patternsSettingString[i-1]].Value = string.Format("{0};{1};{2};{3}", tmp1.GetValue(Info), ((Color)tmp2.GetValue(Info)).ToArgb().GetHashCode().ToString(), ((Color)tmp3.GetValue(Info)).ToArgb().GetHashCode().ToString(), tmp4.GetValue(Info).ToString());
                    //config.Save();
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                    if (tmp1.GetValue(Info).ToString() != "" && !filteringList.Exists(x => x.pattern == tmp1.GetValue(Info).ToString() && x.bgcolor.Equals(((Color)tmp2.GetValue(Info)).ToArgb().GetHashCode()) && x.fgcolor.Equals(((Color)tmp3.GetValue(Info)).ToArgb().GetHashCode()) && x.alert.Equals(bool.Parse(tmp4.GetValue(Info).ToString()))))
                    {
                        filteringList.Add(new FilteringInfo(tmp1.GetValue(Info).ToString(), ((Color)tmp2.GetValue(Info)), ((Color)tmp3.GetValue(Info)), bool.Parse(tmp4.GetValue(Info).ToString())));
                    }
                    //string ttt = string.Format("{0};{1};{2}", tmp1.GetValue(Info), tmp2.GetValue(Info), tmp3.GetValue(Info));
                }
                for (int i = 1; i <= contactsSettingString.Count; i++)
                {
                    check = "saveContactsSettingString" + i.ToString();
                    //var split = appSetting.Get(contactsSettingString[i - 1]).Split(';');
                    var tmp1 = typeof(SettingInfo).GetProperty(contactsSettingNameValue[i - 1]);
                    var tmp2 = typeof(SettingInfo).GetProperty(contactsSettingIDValue[i - 1]);
                    var tmp3 = typeof(SettingInfo).GetProperty(contactsSettingCellPhoneValue[i - 1]);
                    config.AppSettings.Settings[contactsSettingString[i - 1]].Value = string.Format("{0};{1};{2}", tmp1.GetValue(Info).ToString(), tmp2.GetValue(Info).ToString(), tmp3.GetValue(Info).ToString());
                    //config.Save();
                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");

                    if (tmp1.GetValue(Info).ToString() != "" && !contactList.Exists(x => x.name == tmp1.GetValue(Info).ToString() && x.id == tmp2.GetValue(Info).ToString() && x.cellphone == tmp3.GetValue(Info).ToString()))
                    {
                        contactList.Add(new ContactInfo(tmp1.GetValue(Info).ToString(), tmp2.GetValue(Info).ToString(), tmp3.GetValue(Info).ToString()));
                    }
                }
                //propertyGrid1.SelectedObject = Info;
            }
            catch (Exception)
            {
                Console.WriteLine(e.ToString(), check);
            }
        }

        private void Property_Load(object sender, EventArgs e)
        {
            string check = string.Empty;
            try
            {
                Info = new SettingInfo();
                Color aaa = SystemColors.Control;
                var appSetting = ConfigurationManager.AppSettings;
                List<string> patternsSettingString = getSettingsName("Pattern", 20);
                List<string> contactsSettingString = getSettingsName("ContactInfo", 15);
                
                List<string> patternsSettingStringValue = getSettingsNameWithPostfix("Pattern", "_string", 20);
                List<string> patternsSettingBgColorValue = getSettingsNameWithPostfix("Pattern", "_bgcolor", 20);
                List<string> patternsSettingFgColorValue = getSettingsNameWithPostfix("Pattern", "_fgcolor", 20);
                List<string> patternsSettingAlertValue = getSettingsNameWithPostfix("Pattern", "_alert", 20);
                List<string> contactsSettingCellPhoneValue = getSettingsNameWithPostfix("Receiver", "_cell", 15);
                List<string> contactsSettingIDValue = getSettingsNameWithPostfix("Receiver", "_id", 15);
                List<string> contactsSettingNameValue = getSettingsNameWithPostfix("Receiver", "_name", 15);
                for (int i = 1; i <= patternsSettingString.Count; i++)
                {
                    check = "patternsSettingString" + i.ToString();
                    var split = appSetting.Get(patternsSettingString[i-1]).Split(';');
                    var tmp = typeof(SettingInfo).GetProperty(patternsSettingStringValue[i - 1]);
                    tmp.SetValue(Info, (split.Length != 4) ? "" : split[0]);
                    tmp = typeof(SettingInfo).GetProperty(patternsSettingBgColorValue[i - 1]);
                    tmp.SetValue(Info, (split.Length != 4 || split[1] == "") ? Color.FromArgb(524296) : Color.FromArgb(int.Parse(split[1])));
                    tmp = typeof(SettingInfo).GetProperty(patternsSettingFgColorValue[i - 1]);
                    tmp.SetValue(Info, (split.Length != 4 || split[2] == "") ? Color.FromArgb(524296) : Color.FromArgb(int.Parse(split[2])));
                    tmp = typeof(SettingInfo).GetProperty(patternsSettingAlertValue[i - 1]);
                    tmp.SetValue(Info, (split.Length != 4 || split[3] == "") ? false : bool.Parse(split[3]));
                    //if (split[0] != "" && !filteringList.Contains(new FilteringInfo(split[0], Color.FromArgb(int.Parse(split[1])), Color.FromArgb(int.Parse(split[2])))))
                    if (split[0] != "" && !filteringList.Exists(x => x.pattern == split[0] && x.bgcolor.Equals(Color.FromArgb(int.Parse(split[1]))) && x.fgcolor.Equals(Color.FromArgb(int.Parse(split[2]))) && x.alert.Equals(bool.Parse((split[3] == "") ? "false" : split[3]))))
                    {
                        filteringList.Add(new FilteringInfo(split[0], Color.FromArgb(int.Parse(split[1])), Color.FromArgb(int.Parse(split[2])), bool.Parse((split[3] == "") ? "false" : split[3])));
                    }
                }
                for (int i = 1; i <= contactsSettingString.Count; i++)
                {
                    check = "contactsSettingString" + i.ToString();
                    var split = appSetting.Get(contactsSettingString[i-1]).Split(';');
                    var tmp = typeof(SettingInfo).GetProperty(contactsSettingNameValue[i - 1]);
                    tmp.SetValue(Info, (split.Length != 3) ? "" : split[0]);
                    tmp = typeof(SettingInfo).GetProperty(contactsSettingIDValue[i - 1]);
                    tmp.SetValue(Info, (split.Length != 3) ? "" : split[1]);
                    tmp = typeof(SettingInfo).GetProperty(contactsSettingCellPhoneValue[i - 1]);
                    tmp.SetValue(Info, (split.Length != 3) ? "" : split[2]);
                    if (split[0] != "" && !contactList.Exists(x => x.name == split[0] && x.id == split[1] && x.cellphone == split[2]))
                    {
                        contactList.Add(new ContactInfo(split[0], split[1], split[2]));
                    }

                    
                }
                propertyGrid1.SelectedObject = Info;
            }
            catch (Exception)
            {
                Console.WriteLine(e.ToString(), check);
            }
            
        }

        public void Initializing()
        {
            //string check = string.Empty;
            try
            {
                Info = new SettingInfo();
                filteringList = new List<FilteringInfo>();
                contactList = new List<ContactInfo>();
                Color aaa = SystemColors.Control;
                var appSetting = ConfigurationManager.AppSettings;
                List<string> patternsSettingString = getSettingsName("Pattern", 20);
                List<string> contactsSettingString = getSettingsName("ContactInfo", 15);

                List<string> patternsSettingStringValue = getSettingsNameWithPostfix("Pattern", "_string", 20);
                List<string> patternsSettingBgColorValue = getSettingsNameWithPostfix("Pattern", "_bgcolor", 20);
                List<string> patternsSettingFgColorValue = getSettingsNameWithPostfix("Pattern", "_fgcolor", 20);
                List<string> patternsSettingAlertValue = getSettingsNameWithPostfix("Pattern", "_alert", 20);
                List<string> contactsSettingCellPhoneValue = getSettingsNameWithPostfix("Receiver", "_cell", 15);
                List<string> contactsSettingIDValue = getSettingsNameWithPostfix("Receiver", "_id", 15);
                List<string> contactsSettingNameValue = getSettingsNameWithPostfix("Receiver", "_name", 15);
                for (int i = 1; i <= patternsSettingString.Count; i++)
                {
                    //check = "patternsSettingString" + i.ToString();
                    var split = appSetting.Get(patternsSettingString[i - 1]).Split(';');
                    var tmp = typeof(SettingInfo).GetProperty(patternsSettingStringValue[i - 1]);
                    tmp.SetValue(Info, (split.Length != 4) ? "" : split[0]);
                    tmp = typeof(SettingInfo).GetProperty(patternsSettingBgColorValue[i - 1]);
                    tmp.SetValue(Info, (split.Length != 4 || split[1] == "") ? Color.FromArgb(524296) : Color.FromArgb(int.Parse(split[1])));
                    tmp = typeof(SettingInfo).GetProperty(patternsSettingFgColorValue[i - 1]);
                    tmp.SetValue(Info, (split.Length != 4 || split[2] == "") ? Color.FromArgb(524296) : Color.FromArgb(int.Parse(split[2])));
                    tmp = typeof(SettingInfo).GetProperty(patternsSettingAlertValue[i - 1]);
                    tmp.SetValue(Info, (split.Length != 4 || split[3] == "") ? false : bool.Parse(split[3]));
                    if (split[0] != "")
                    {
                        filteringList.Add(new FilteringInfo(split[0], Color.FromArgb(int.Parse(split[1])), Color.FromArgb(int.Parse(split[2])), bool.Parse(split[3])));
                    }
                }
                for (int i = 1; i <= contactsSettingString.Count; i++)
                {
                    //check = "contactsSettingString" + i.ToString();
                    var split = appSetting.Get(contactsSettingString[i - 1]).Split(';');
                    var tmp = typeof(SettingInfo).GetProperty(contactsSettingNameValue[i - 1]);
                    tmp.SetValue(Info, (split.Length != 3) ? "" : split[0]);
                    tmp = typeof(SettingInfo).GetProperty(contactsSettingIDValue[i - 1]);
                    tmp.SetValue(Info, (split.Length != 3) ? "" : split[1]);
                    tmp = typeof(SettingInfo).GetProperty(contactsSettingCellPhoneValue[i - 1]);
                    tmp.SetValue(Info, (split.Length != 3) ? "" : split[2]);
                    if (split[0] != "")
                    {
                        contactList.Add(new ContactInfo(split[0], split[1], split[2]));
                    }
                }
                propertyGrid1.SelectedObject = Info;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

        }
        private List<string> getSettingsName(string prefix, int count)
        {
            List<string> retStrArr = new List<string>();
            for(int i=1;i<= count; i++)
            {
                if (i > 9)
                {
                    retStrArr.Add(string.Format("{0}{1}", prefix, i.ToString()));
                }
                else
                {
                    retStrArr.Add(string.Format("{0}0{1}", prefix, i.ToString()));
                }
                
            }
            return retStrArr;
        }

        private List<string> getSettingsNameWithPostfix(string prefix, string postfix, int count)
        {
            List<string> retStrArr = new List<string>();
            for (int i = 1; i <= count; i++)
            {
                if (i > 9)
                {
                    retStrArr.Add(string.Format("{0}{1}{2}", prefix, i.ToString(), postfix));
                }
                else
                {
                    retStrArr.Add(string.Format("{0}0{1}{2}", prefix, i.ToString(), postfix));
                }

            }
            return retStrArr;
        }
    }
}
