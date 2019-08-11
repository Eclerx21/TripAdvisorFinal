using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Database;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Trip_Advisor
{
    public class SecondFragment : Fragment
    {
        static string[] placesArray = { "CN TOWER", "WONDERLAND", "NIAGRA FALLS", "BLUFFERS PARK", "TORONTO ISLAND"};
        public string email;
        public string myName;
        public Activity myContext;

        PlacesDataModel cdm = new PlacesDataModel();

        ArrayAdapter myAdapterarray;
        ArrayList listCode = new ArrayList();
        ListView myList;


        public static string codeTitle = "title";
        public static string codelink = "link";
        public static string codeDesc = "discription";
        public static string codeID = "id";
        public static string codeImage = "image";

        

        string code_title, code_link, code_desc = "";
        string code_id = "", code_image = "";



        public SecondFragment(string email)
        {
            this.email = email;
        }

        public SecondFragment()
        {
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment

            View myView = inflater.Inflate(Resource.Layout.activity_countries_tab, container, false);
            myList = myView.FindViewById<ListView>(Resource.Id.listView1);

            //TextView mytext = myView.FindViewById<TextView>(Resource.Id.textView1);
            SearchView mySearch = myView.FindViewById<SearchView>(Resource.Id.searchView1);

            //myView.FindViewById<TextView>(Resource.Id.textView1).Text = myName;

            // mytext.Text = "Code List";
            //myList.Adapter = new ArrayAdapter(myContext, Android.Resource.Layout.SimpleListItem1, movieArray);

            // Code to display Code List

            ICursor myresult = cdm.PrintCodeList(this.Activity);


            listCode.Clear();

            //while (myresult.MoveToNext())
            //{
            //    //myEmail = myresult.GetString(myresult.GetColumnIndexOrThrow(emailValue));
            //    // working code
            //    code_id = myresult.GetString(myresult.GetColumnIndexOrThrow(codeID));
            //    code_title = myresult.GetString(myresult.GetColumnIndexOrThrow(codeTitle));
            //    code_link = myresult.GetString(myresult.GetColumnIndexOrThrow(codelink));
            //    code_desc = myresult.GetString(myresult.GetColumnIndexOrThrow(codeDesc));
            //    code_image = myresult.GetString(myresult.GetColumnIndexOrThrow(codeImage));

            //    listCode.Add(myresult.GetString(myresult.GetColumnIndexOrThrow(codeTitle)));

            //    //custom Adaptor addition
            //}
            myAdapterarray = new ArrayAdapter(this.Activity, Android.Resource.Layout.SimpleListItem1, placesArray);
            myList.Adapter = myAdapterarray;
            myList.ItemClick += MyList_ItemClick;
            mySearch.QueryTextChange += MySearch_QueryTextChange;

           
            return myView;

        }

        private void MySearch_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(e.NewText))
            {
                myAdapterarray = new ArrayAdapter(this.Activity, Android.Resource.Layout.SimpleListItem1, listCode);
                myList.Adapter = myAdapterarray;
            }
            else
            {
                var mySearchValue = e.NewText;
                myAdapterarray.Filter.InvokeFilter(mySearchValue);
            }

        }

        private void MyList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //var index = e.Position;
            //code_title = (string)listCode[index];

            //Intent newScreen = new Intent(this.Activity, typeof(CodeViewActivity));
            //newScreen.PutExtra("code_id", code_id);
            //newScreen.PutExtra("email", email);
            //newScreen.PutExtra("code_title", code_title);
            //newScreen.PutExtra("code_link", code_link);
            //newScreen.PutExtra("code_desc", code_desc);
            //StartActivity(newScreen);






        }
    }
}