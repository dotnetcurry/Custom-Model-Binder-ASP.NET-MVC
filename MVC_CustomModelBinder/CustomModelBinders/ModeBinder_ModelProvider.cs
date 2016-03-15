using System;
using System.Web;

using System.Web.Mvc;
using System.Xml.Serialization;

namespace MVC_CustomModelBinder.CustomModelBinders
{
    public class XMLToObjectModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {
                //1.
                var model = bindingContext.ModelType;
                //2.
                var data = new XmlSerializer(model);
                //3.
                var receivedStream = controllerContext.HttpContext.Request.InputStream;
                //4.
                return data.Deserialize(receivedStream);
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.AddModelError("Error", "Received Model cannot be serialized");
                return null;
            }

        }
    }
    public class XMLToObjectModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            //5.
            var receivedContentType = HttpContext.Current.Request.ContentType.ToLower();
            if (receivedContentType != "text/xml")
            {
                return null;
            }

            return new XMLToObjectModelBinder();
        }
    }

}

