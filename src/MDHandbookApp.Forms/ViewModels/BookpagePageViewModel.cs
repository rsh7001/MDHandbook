﻿//
//  Copyright 2016  R. Stanley Hum <r.stanley.hum@gmail.com>
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//        http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//

using System;
using System.Runtime.Serialization;
using MDHandbookApp.Forms.Services;
using MDHandbookApp.Forms.States;
using Prism.Navigation;
using Xamarin.Forms;


namespace MDHandbookApp.Forms.ViewModels
{
    [DataContract]
    public class BookpagePageViewModel : ViewModelBase
    {
        
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        [IgnoreDataMember]
        private WebViewSource _source;

        [IgnoreDataMember]
        public WebViewSource Source
        {
            get { return _source; }
            set { SetProperty(ref _source, value); }
        }

        public BookpagePageViewModel(
            ILogService logService,
            INavigationService navigationService,
            IReduxService reduxService) : base(logService, navigationService, reduxService)
        {
        }

        public void WebOnNavigating(object s, WebNavigatingEventArgs e)
        {
            string fullpageUrl = e.Url.ToString();
            string fullpageId = "";

            _logService.Info($"BookpageNavigateTo:{fullpageUrl}");

            if (fullpageUrl.StartsWith(Constants.WebpageUrlWebStartId))
            {
                Source = new UrlWebViewSource { Url = fullpageUrl };
                return;
            }

            if (fullpageUrl.StartsWith(Constants.WebpageUrlHybridStartId))
            {
                fullpageId = fullpageUrl.Remove(0, 9);
                _navigationService.NavigateAsync($"{Constants.BookpagePageRelUrl}?{Constants.BookpagePageUrlParamId}={fullpageId}");
                e.Cancel = true;
                return;
            }
        }

        public void WebOnEndNavigating(object s, WebNavigatedEventArgs e)
        {
        }

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            string fullpageUrl;
            Fullpage fullpage;
            try
            {
                fullpageUrl = (string)parameters[Constants.BookpagePageUrlParamId];
                _logService.Info($"{fullpageUrl}");
                fullpage = _reduxService.Store.GetState().Fullpages[fullpageUrl];
                Source = fullpage.Content;
                Title = fullpage.Title;
                return;
            }
            catch(Exception)
            {
                Source = "";
                Title = "No Page";
                _logService.Debug("NoPage");
                return;
            }

            
        }




    }
}
