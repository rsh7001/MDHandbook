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
using Redux;


namespace MDHandbookApp.Forms.Actions
{
    public class ClearUnauthorizedCountAction : IAction { }

    public class IncrementUnauthorizedCountAction : IAction { }

    public class SetIsNetworkDownAction : IAction
    {
        public DateTimeOffset NetworkDownLastAttemptDateTime { get; set; }
    }

    public class ClearIsNetworkDownAction : IAction { }

    public class SetIsNetworkBusyAction : IAction { }

    public class ClearIsNetworkBusyAction : IAction { }

    public class SetLoginSuccessfulAction : IAction { }

    public class SetLoginNotSuccessfulAction : IAction { }

    public class ClearLoginSuccessfullAction : IAction { }

    public class SetLicenceKeySuccessfulAction : IAction { }

    public class SetLicenceKeyNotSuccessfulAction : IAction { }

    public class ClearLicenceKeySuccessfulAction : IAction { }

    public class SetUnauthorizedErrorAction : IAction { }

    public class ClearUnauthorizedErrorAction : IAction { }

    public class SetReturnToMainPageAction : IAction { }

    public class ClearReturnToMainPageAction : IAction { }

    public class SetNeedsUpdateAction : IAction { }

    public class ClearNeedsUpdateAction : IAction { }
}
