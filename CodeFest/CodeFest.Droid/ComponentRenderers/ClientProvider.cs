using Android.Content;
using Android.Database;
using Android.Net;

namespace CodeFest.Droid.ComponentRenderers
{
    internal class ClientProvider : ContentProvider
    {
        public override int Delete(Uri uri, string selection, string[] selectionArgs)
        {
            throw new System.NotImplementedException();
        }

        public override string GetType(Uri uri)
        {
            throw new System.NotImplementedException();
        }

        public override Uri Insert(Uri uri, ContentValues values)
        {
            throw new System.NotImplementedException();
        }

        public override bool OnCreate()
        {
            throw new System.NotImplementedException();
        }

        public override ICursor Query(Uri uri, string[] projection, string selection, string[] selectionArgs, string sortOrder)
        {
            throw new System.NotImplementedException();
        }

        public override int Update(Uri uri, ContentValues values, string selection, string[] selectionArgs)
        {
            throw new System.NotImplementedException();
        }
    }
}