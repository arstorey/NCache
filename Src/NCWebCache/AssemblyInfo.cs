// Copyright (c) 2018 Alachisoft
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//    http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

//
// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
//
#if !DEBUG
[assembly: CLSCompliant(true)]
#endif

[assembly: ComVisible(false)]
#if NETCORE
[assembly: AssemblyTitle("Alachisoft.NCache.Web (.NETCore)")]
#else
[assembly: AssemblyTitle("Alachisoft.NCache.Web")]
#endif


[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Alachisoft")]
[assembly: AssemblyProduct("Alachisoft® NCache Open Source")]

[assembly: AssemblyCopyright("Copyright © 2005-2018 Alachisoft")]
[assembly: AssemblyTrademark("NCache ™ is a registered trademark of Alachisoft.")]

[assembly: AssemblyCulture("")]

//
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version 
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Revision and Build Numbers 
// by using the '*' as shown below:

[assembly: AssemblyVersion("4.9.0")]
[assembly: AssemblyDescriptionAttribute("Web API")]
[assembly: AssemblyFileVersionAttribute("4.9.1.0")]
[assembly: AssemblyInformationalVersion("4.9.0")]
