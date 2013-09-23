﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http.Formatting;
using System.Web.Http;
using Umbraco.Core;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;
using umbraco.BusinessLogic.Actions;
using Umbraco.Web.Trees.Menu;

namespace Merchello.Web.UI.Trees
{
    [Tree("merchello", "merchello", "Merchello Tree")]
    public class MerchelloTreeController : TreeApiController
    {
        protected override TreeNodeCollection GetTreeNodes(string id, FormDataCollection queryStrings)
        {
            //we only support one tree level for data types
            //if (id != Constants.System.Root.ToInvariantString())
            //{
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            //}
            var collection = new TreeNodeCollection();
            if (id == "settings")
            {
                collection.Add(CreateTreeNode("regions", queryStrings, "Regions", "icon-autofill", false));
                collection.Add(CreateTreeNode("shipping", queryStrings, "Shipping", "icon-autofill", false));
                collection.Add(CreateTreeNode("taxation", queryStrings, "Taxation", "icon-autofill", false));
                collection.Add(CreateTreeNode("payment", queryStrings, "Payment", "icon-autofill", false));
                collection.Add(CreateTreeNode("debuglog", queryStrings, "Debug Log", "icon-autofill", false));
            }
            else
            {
                collection.Add(CreateTreeNode("catalog", queryStrings, "Catalog", "icon-autofill", false));
                collection.Add(CreateTreeNode("invoice", queryStrings, "Invoice", "icon-autofill", false));
                collection.Add(CreateTreeNode("customers", queryStrings, "Customers", "icon-autofill", false));
                collection.Add(CreateTreeNode("reports", queryStrings, "Reports", "icon-autofill", false));
                collection.Add(CreateTreeNode("settings", queryStrings, "Settings", "icon-autofill", true));
            }

            //collection.AddRange(
            //    Services.DataTypeService.GetAllDataTypeDefinitions()
            //            .OrderBy(x => x.Name)
            //            .Select(dt =>
            //                    CreateTreeNode(
            //                        dt.Id.ToInvariantString(),
            //                        queryStrings,
            //                        dt.Name,
            //                        "icon-autofill",
            //                        false)));
            return collection;
        }

        protected override MenuItemCollection GetMenuForNode(string id, FormDataCollection queryStrings)
        {
            var menu = new MenuItemCollection();

            if (id == Constants.System.Root.ToInvariantString())
            {
                // root actions              
                menu.AddMenuItem<CreateChildEntity, ActionNew>();
                menu.AddMenuItem<RefreshNode, ActionRefresh>(true);
                return menu;
            }

            //only have delete for each node
            menu.AddMenuItem<ActionDelete>();
            return menu;
        }

    }
}