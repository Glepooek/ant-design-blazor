﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Threading.Tasks;
using AntDesign.Docs.Services;
using AntDesign.Extensions.Localization;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Docs.Shared
{
    public partial class MainLayout : LayoutComponentBase
    {
        private bool _drawerVisible = false;

        public string CurrentLanguage => LocalizationService.CurrentCulture.Name;

        private bool _isMobile;

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ILocalizationService LocalizationService { get; set; }

        [Inject]
        public DemoService DemoService { get; set; }

        internal PrevNextNav PrevNextNav { get; set; }

        public async Task ChangePrevNextNav(string currentTitle)
        {
            if (string.IsNullOrWhiteSpace(currentTitle))
                return;

            var currentSubmenuUrl = DemoService.GetCurrentSubMenuUrl();
            var prevNext = await DemoService.GetPrevNextMenu(currentSubmenuUrl, currentTitle);

            PrevNextNav?.SetPrevNextNav(prevNext[0], prevNext[1]);
        }
    }
}
