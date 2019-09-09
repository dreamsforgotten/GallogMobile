using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Refit;
using Gallog.Models;

namespace Gallog.Interface
{
    public interface IAPIParser
    {
        [Get("/users")]
        Task<List<MyUser>> GetUsers();
    }

}
