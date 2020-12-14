﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncOperations
{
    class DownloadProgressChangedEventArgs : EventArgs
    {
        public int Progress { get; set; }
    }

    class WebServer
    {
        private static int DownloadDuration = 5000;
        private static string PageContent = @"<!DOCTYPE html>
<html lang=""en"" dir=""ltr"" class=""client-nojs"">
<head>
<title>std::atomic - cppreference.com</title>
<meta charset=""UTF-8"" />
<meta name=""generator"" content=""MediaWiki 1.21.2"" />
<link rel=""alternate"" type=""application/x-wiki"" title=""Edit"" href=""/mwiki/index.php?title=cpp/atomic/atomic&amp;action=edit"" />
<link rel=""edit"" title=""Edit"" href=""/mwiki/index.php?title=cpp/atomic/atomic&amp;action=edit"" />
<link rel=""shortcut icon"" href=""/favicon.ico"" />
<link rel=""search"" type=""application/opensearchdescription+xml"" href=""/mwiki/opensearch_desc.php"" title=""cppreference.com (en)"" />
<link rel=""EditURI"" type=""application/rsd+xml"" href=""https://en.cppreference.com/mwiki/api.php?action=rsd"" />
<link rel=""alternate"" type=""application/atom+xml"" title=""cppreference.com Atom feed"" href=""/mwiki/index.php?title=Special:RecentChanges&amp;feed=atom"" />
<link rel=""stylesheet"" href=""https://en.cppreference.com/mwiki/load.php?debug=false&amp;lang=en&amp;modules=ext.gadget.ColiruCompiler%2CMathJax%7Cext.rtlcite%7Cmediawiki.legacy.commonPrint%2Cshared%7Cskins.cppreference2&amp;only=styles&amp;skin=cppreference2&amp;*"" />
<meta name=""ResourceLoaderDynamicStyles"" content="""" />
<link rel=""stylesheet"" href=""https://en.cppreference.com/mwiki/load.php?debug=false&amp;lang=en&amp;modules=site&amp;only=styles&amp;skin=cppreference2&amp;*"" />
<style>a:lang(ar),a:lang(ckb),a:lang(fa),a:lang(kk-arab),a:lang(mzn),a:lang(ps),a:lang(ur){text-decoration:none}#toc{display:none}.editsection{display:none}
/* cache key: mwiki1-mwiki_en_:resourceloader:filter:minify-css:7:472787eddcf4605d11de8c7ef047234f */</style>

<script src=""https://en.cppreference.com/mwiki/load.php?debug=false&amp;lang=en&amp;modules=startup&amp;only=scripts&amp;skin=cppreference2&amp;*""></script>
<script>if(window.mw){
mw.config.set({""wgCanonicalNamespace"":"""",""wgCanonicalSpecialPageName"":false,""wgNamespaceNumber"":0,""wgPageName"":""cpp/atomic/atomic"",""wgTitle"":""cpp/atomic/atomic"",""wgCurRevisionId"":124339,""wgArticleId"":4734,""wgIsArticle"":true,""wgAction"":""view"",""wgUserName"":null,""wgUserGroups"":[""*""],""wgCategories"":[],""wgBreakFrames"":false,""wgPageContentLanguage"":""en"",""wgSeparatorTransformTable"":["""",""""],""wgDigitTransformTable"":["""",""""],""wgDefaultDateFormat"":""dmy"",""wgMonthNames"":["""",""January"",""February"",""March"",""April"",""May"",""June"",""July"",""August"",""September"",""October"",""November"",""December""],""wgMonthNamesShort"":["""",""Jan"",""Feb"",""Mar"",""Apr"",""May"",""Jun"",""Jul"",""Aug"",""Sep"",""Oct"",""Nov"",""Dec""],""wgRelevantPageName"":""cpp/atomic/atomic"",""wgRestrictionEdit"":[],""wgRestrictionMove"":[]});
}</script><script>if(window.mw){
mw.loader.implement(""user.options"",function(){mw.user.options.set({""ccmeonemails"":0,""cols"":80,""date"":""default"",""diffonly"":0,""disablemail"":0,""disablesuggest"":0,""editfont"":""default"",""editondblclick"":0,""editsection"":0,""editsectiononrightclick"":0,""enotifminoredits"":0,""enotifrevealaddr"":0,""enotifusertalkpages"":1,""enotifwatchlistpages"":0,""extendwatchlist"":0,""externaldiff"":0,""externaleditor"":0,""fancysig"":0,""forceeditsummary"":0,""gender"":""unknown"",""hideminor"":0,""hidepatrolled"":0,""imagesize"":2,""justify"":0,""math"":1,""minordefault"":0,""newpageshidepatrolled"":0,""nocache"":0,""noconvertlink"":0,""norollbackdiff"":0,""numberheadings"":0,""previewonfirst"":0,""previewontop"":1,""quickbar"":5,""rcdays"":7,""rclimit"":50,""rememberpassword"":0,""rows"":25,""searchlimit"":20,""showhiddencats"":0,""showjumplinks"":1,""shownumberswatching"":1,""showtoc"":0,""showtoolbar"":1,""skin"":""cppreference2"",""stubthreshold"":0,""thumbsize"":2,""underline"":2,""uselivepreview"":0,""usenewrc"":0,""watchcreations"":0,""watchdefault"":0,""watchdeletion"":0,
""watchlistdays"":3,""watchlisthideanons"":0,""watchlisthidebots"":0,""watchlisthideliu"":0,""watchlisthideminor"":0,""watchlisthideown"":0,""watchlisthidepatrolled"":0,""watchmoves"":0,""wllimit"":250,""variant"":""en"",""language"":""en"",""searchNs0"":true,""searchNs1"":false,""searchNs2"":false,""searchNs3"":false,""searchNs4"":false,""searchNs5"":false,""searchNs6"":false,""searchNs7"":false,""searchNs8"":false,""searchNs9"":false,""searchNs10"":false,""searchNs11"":false,""searchNs12"":false,""searchNs13"":false,""searchNs14"":false,""searchNs15"":false,""gadget-ColiruCompiler"":1,""gadget-MathJax"":1});;},{},{});mw.loader.implement(""user.tokens"",function(){mw.user.tokens.set({""editToken"":""+\\"",""patrolToken"":false,""watchToken"":false});;},{},{});
/* cache key: mwiki1-mwiki_en_:resourceloader:filter:minify-js:7:9f05c6caceb9bb1a482b6cebd4c5a330 */
}</script>
<script>if(window.mw){
mw.loader.load([""mediawiki.page.startup"",""mediawiki.legacy.wikibits"",""mediawiki.legacy.ajax""]);
}</script>
<style type=""text/css"">/*<![CDATA[*/
.source-cpp {line-height: normal;}
.source-cpp li, .source-cpp pre {
	line-height: normal; border: 0px none white;
}
/**
 * GeSHi Dynamically Generated Stylesheet
 * --------------------------------------
 * Dynamically generated stylesheet for cpp
 * CSS class: source-cpp, CSS id: 
 * GeSHi (C) 2004 - 2007 Nigel McNie, 2007 - 2008 Benny Baumann
 * (http://qbnz.com/highlighter/ and http://geshi.org/)
 * --------------------------------------
 */
.cpp.source-cpp .de1, .cpp.source-cpp .de2 {font: normal normal 1em/1.2em monospace; margin:0; padding:0; background:none; vertical-align:top;}
.cpp.source-cpp  {font-family:monospace;}
.cpp.source-cpp .imp {font-weight: bold; color: red;}
.cpp.source-cpp li, .cpp.source-cpp .li1 {font-weight: normal; vertical-align:top;}
.cpp.source-cpp .ln {width:1px;text-align:right;margin:0;padding:0 2px;vertical-align:top;}
.cpp.source-cpp .li2 {font-weight: bold; vertical-align:top;}
.cpp.source-cpp .kw1 {color: #0000dd;}
.cpp.source-cpp .kw2 {color: #0000ff;}
.cpp.source-cpp .kw3 {color: #0000dd;}
.cpp.source-cpp .kw4 {color: #0000ff;}
.cpp.source-cpp .co1 {color: #909090;}
.cpp.source-cpp .co2 {color: #339900;}
.cpp.source-cpp .coMULTI {color: #ff0000; font-style: italic;}
.cpp.source-cpp .es0 {color: #008000; font-weight: bold;}
.cpp.source-cpp .es1 {color: #008000; font-weight: bold;}
.cpp.source-cpp .es2 {color: #008000; font-weight: bold;}
.cpp.source-cpp .es3 {color: #008000; font-weight: bold;}
.cpp.source-cpp .es4 {color: #008000; font-weight: bold;}
.cpp.source-cpp .es5 {color: #008000; font-weight: bold;}
.cpp.source-cpp .br0 {color: #008000;}
.cpp.source-cpp .sy0 {color: #008000;}
.cpp.source-cpp .sy1 {color: #000080;}
.cpp.source-cpp .sy2 {color: #000040;}
.cpp.source-cpp .sy3 {color: #000040;}
.cpp.source-cpp .sy4 {color: #008080;}
.cpp.source-cpp .st0 {color: #008000;}
.cpp.source-cpp .nu0 {color: #000080;}
.cpp.source-cpp .nu6 {color: #000080;}
.cpp.source-cpp .nu8 {color: #000080;}
.cpp.source-cpp .nu12 {color: #000080;}
.cpp.source-cpp .nu16 {color:#000080;}
.cpp.source-cpp .nu17 {color:#000080;}
.cpp.source-cpp .nu18 {color:#000080;}
.cpp.source-cpp .nu19 {color:#000080;}
.cpp.source-cpp .ln-xtra, .cpp.source-cpp li.ln-xtra, .cpp.source-cpp div.ln-xtra {background-color: #ffc;}
.cpp.source-cpp span.xtra { display:block; }

/*]]>*/
</style><!--[if lt IE 7]><style type=""text/css"">body{behavior:url(""/mwiki/skins/cppreference2/csshover.min.htc"")}</style><![endif]--></head>
<body class=""mediawiki ltr sitedir-ltr ns-0 ns-subject page-cpp_atomic_atomic skin-cppreference2 action-view cpp-navbar"">
        <!-- header -->
        <div id=""mw-head"" class=""noprint"">
            <div id=""cpp-head-first-base"">
                <div id=""cpp-head-first"">
                    <h5><a href=""/"">
                        cppreference.com                        </a></h5>
                    <div id=""cpp-head-search"">
                        
<!-- 0 -->
<div id=""p-search"">
	<h5><label for=""searchInput"">Search</label></h5>
	<form action=""/mwiki/index.php"" id=""searchform"">
		<input type='hidden' name=""title"" value=""Special:Search""/>
				<div id=""simpleSearch"">
						<input name=""search"" title=""Search cppreference.com [f]"" accesskey=""f"" id=""searchInput"" />						<button type=""submit"" name=""button"" title=""Search the pages for this text"" id=""searchButton""><img src=""/mwiki/skins/cppreference2/images/search-ltr.png?303"" alt=""Search"" /></button>					</div>
			</form>
</div>

<!-- /0 -->
                    </div>
                    <div id=""cpp-head-personal"">
                        
<!-- 0 -->
<div id=""p-personal"" class="""">
<span id=""pt-createaccount""><a href=""/mwiki/index.php?title=Special:UserLogin&amp;returnto=cpp%2Fatomic%2Fatomic&amp;type=signup"">Create account</a></span>	<div class=""menu"">
        <ul>
<li id=""pt-login""><a href=""/mwiki/index.php?title=Special:UserLogin&amp;returnto=cpp%2Fatomic%2Fatomic"" title=""You are encouraged to log in; however, it is not mandatory [o]"" accesskey=""o"">Log in</a></li>        </ul>
    </div>
</div>

<!-- /0 -->
                    </div>

                </div>
            </div>
            <div id=""cpp-head-second-base"">
                <div id=""cpp-head-second"">
                    <div id=""cpp-head-tools-left"">
                        
<!-- 0 -->
<div id=""p-namespaces"" class=""vectorTabs"">
	<h5>Namespaces</h5>
	<ul>
					<li  id=""ca-nstab-main"" class=""selected""><span><a href=""/w/cpp/atomic/atomic""  title=""View the content page [c]"" accesskey=""c"">Page</a></span></li>
					<li  id=""ca-talk""><span><a href=""/w/Talk:cpp/atomic/atomic""  title=""Discussion about the content page [t]"" accesskey=""t"">Discussion</a></span></li>
			</ul>
</div>

<!-- /0 -->

<!-- 1 -->
<div id=""p-variants"" class=""vectorMenu emptyPortlet"">
		<h5><span>Variants</span><a href=""#""></a></h5>
	<div class=""menu"">
		<ul>
					</ul>
	</div>
</div>

<!-- /1 -->
                    </div>
                    <div id=""cpp-head-tools-right"">
                        
<!-- 0 -->
<div id=""p-views"" class=""vectorTabs"">
	<h5>Views</h5>
	<ul>
					<li id=""ca-view"" class=""selected""><span><a href=""/w/cpp/atomic/atomic"" >View</a></span></li>
					<li id=""ca-edit""><span><a href=""/mwiki/index.php?title=cpp/atomic/atomic&amp;action=edit""  title=""You can edit this page. Please use the preview button before saving [e]"" accesskey=""e"">Edit</a></span></li>
					<li id=""ca-history"" class=""collapsible""><span><a href=""/mwiki/index.php?title=cpp/atomic/atomic&amp;action=history""  title=""Past revisions of this page [h]"" accesskey=""h"">History</a></span></li>
			</ul>
</div>

<!-- /0 -->

<!-- 1 -->
<div id=""p-cactions"" class=""vectorMenu emptyPortlet"">
	<h5><span>Actions</span><a href=""#""></a></h5>
	<div class=""menu"">
		<ul>
					</ul>
	</div>
</div>

<!-- /1 -->
                    </div>
                </div>
            </div>
        </div>
        <!-- /header -->
        <!-- content -->
<script type=""text/javascript"">
(function(){
  var bsa = document.createElement('script');
     bsa.type = 'text/javascript';
     bsa.async = true;
     bsa.src = '//s3.buysellads.com/ac/bsa.js';
  (document.getElementsByTagName('head')[0]||document.getElementsByTagName('body')[0]).appendChild(bsa);
})();
</script>
<style>
.bsap{position:absolute;left:-150px;margin-top:27px;font-family:-apple-system,BlinkMacSystemFont,'Segoe UI',Roboto,Oxygen-Sans,Ubuntu,Cantarell,'Helvetica Neue',Helvetica,Arial,sans-serif;font-size:12px;line-height:1.5;overflow:hidden;max-width:130px;text-align:center;border:solid 1px hsla(0,0%,0%,.1);border-radius:4px;background-color:#f9f9f9}
.bsap a{text-decoration:none;color:inherit}
.bsap a:hover{color:inherit}
.bsa_it_i img{max-width:130px;height:auto}
.bsa_it_ad>a:nth-child(2){display:block;padding:0 8px}
.bsa_it_t{font-weight:600}
.bsa_it_t:after{content:' — '}
.bsa_it_p{display:block;padding:8px 12px;font-size:9px;font-weight:600;line-height:1;letter-spacing:.5px;text-transform:uppercase;background:repeating-linear-gradient(-45deg,transparent,transparent 5px,hsla(0,0%,0%,.025) 5px,hsla(0,0%,0%,.025) 10px) hsla(203,11%,95%,.4)}
#carbonads{display:block;overflow:hidden}
#carbonads span{display:block;position:relative;overflow:hidden}
.carbon-img{display:block;margin-bottom:8px;line-height:1;max-width:130px}
.carbon-img img{display:block;margin:0 auto;width:130px;max-width:130px!important;height:auto}
.carbon-text{display:block;padding:0 1em 8px}
.carbon-poweredby{display:none}
html { font-variant-ligatures: no-common-ligatures; }
</style>
        <div id=""cpp-content-base"">
            <div id=""content"">
                <a id=""top""></a>
                <div id=""mw-js-message"" style=""display:none;""></div>
                                <!-- firstHeading -->
<div id=""bsap_1308987"" class=""bsarocks bsap_806b7512f50f84c15e2a20e379480845""></div>
                <h1 id=""firstHeading"" class=""firstHeading""><span style=""font-size:0.7em; line-height:130%"">std::</span>atomic</h1>
                <!-- /firstHeading -->
                <!-- bodyContent -->
                <div id=""bodyContent"">
                                        <!-- tagline -->
                    <div id=""siteSub"">From cppreference.com</div>
                    <!-- /tagline -->
                                        <!-- subtitle -->
                    <div id=""contentSub""><span class=""subpages"">&lt; <a href=""/w/cpp"" title=""cpp"">cpp</a>&lrm; | <a href=""/w/cpp/atomic"" title=""cpp/atomic"">atomic</a></span></div>
                    <!-- /subtitle -->
                                                            <!-- bodycontent -->
                    <div id=""mw-content-text"" lang=""en"" dir=""ltr"" class=""mw-content-ltr""><div class=""t-navbar"" style=""""><div class=""t-navbar-sep"">&#160;</div><div class=""t-navbar-head""><a href=""/w/cpp"" title=""cpp""> C++</a><div class=""t-navbar-menu""><div><div><table class=""t-nv-begin"" cellpadding=""0"" style=""line-height:1.1em;"">
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/language"" title=""cpp/language""> Language</a> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/header"" title=""cpp/header""> Standard Library Headers</a> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/freestanding"" title=""cpp/freestanding""> Freestanding and hosted implementations</a> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/named_req"" title=""cpp/named req""> Named requirements </a> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/utility#Language_support"" title=""cpp/utility""> Language support library</a> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/concepts"" title=""cpp/concepts""> Concepts library</a> <span class=""t-mark-rev t-since-cxx20"">(C++20)</span> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/error"" title=""cpp/error""> Diagnostics library</a> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/utility"" title=""cpp/utility""> Utilities library</a> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/string"" title=""cpp/string""> Strings library</a> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/container"" title=""cpp/container""> Containers library</a> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/iterator"" title=""cpp/iterator""> Iterators library</a> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/ranges"" title=""cpp/ranges""> Ranges library</a> <span class=""t-mark-rev t-since-cxx20"">(C++20)</span> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/algorithm"" title=""cpp/algorithm""> Algorithms library</a> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/numeric"" title=""cpp/numeric""> Numerics library</a> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/locale"" title=""cpp/locale""> Localizations library</a> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/io"" title=""cpp/io""> Input/output library</a> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/filesystem"" title=""cpp/filesystem""> Filesystem library</a> <span class=""t-mark-rev t-since-cxx17"">(C++17)</span> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/regex"" title=""cpp/regex""> Regular expressions library</a> <span class=""t-mark-rev t-since-cxx11"">(C++11)</span> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/atomic"" title=""cpp/atomic""> Atomic operations library</a> <span class=""t-mark-rev t-since-cxx11"">(C++11)</span> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/thread"" title=""cpp/thread""> Thread support library</a> <span class=""t-mark-rev t-since-cxx11"">(C++11)</span> </td></tr>
<tr class=""t-nv""><td colspan=""5""> <a href=""/w/cpp/experimental"" title=""cpp/experimental""> Technical Specifications</a> </td></tr>
</table></div><div><span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/navbar_content&amp;action=edit"">&#91;edit&#93;</a></span></div></div></div></div><div class=""t-navbar-sep"">&#160;</div><div class=""t-navbar-head""><a href=""/w/cpp/atomic"" title=""cpp/atomic""> Atomic operations library</a><div class=""t-navbar-menu""><div><div><table class=""t-nv-begin"" cellpadding=""0"" style="""">
<tr class=""t-nv-h1""><td colspan=""5""> Types</td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><strong class=""selflink""><span class=""t-lines""><span>atomic</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_ref"" title=""cpp/atomic/atomic ref""><span class=""t-lines""><span>atomic_ref</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div></td></tr>
<tr class=""t-nv-h1""><td colspan=""5""> Functions</td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_store"" title=""cpp/atomic/atomic store""><span class=""t-lines""><span>atomic_store</span><span>atomic_store_explicit</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_load"" title=""cpp/atomic/atomic load""><span class=""t-lines""><span>atomic_load</span><span>atomic_load_explicit</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_exchange"" title=""cpp/atomic/atomic exchange""><span class=""t-lines""><span>atomic_exchange</span><span>atomic_exchange_explicit</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_compare_exchange"" title=""cpp/atomic/atomic compare exchange""><span class=""t-lines""><span>atomic_compare_exchange_weak</span><span>atomic_compare_exchange_weak_explicit</span><span>atomic_compare_exchange_strong</span><span>atomic_compare_exchange_strong_explicit</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_fetch_add"" title=""cpp/atomic/atomic fetch add""><span class=""t-lines""><span>atomic_fetch_add</span><span>atomic_fetch_add_explicit</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_fetch_sub"" title=""cpp/atomic/atomic fetch sub""><span class=""t-lines""><span>atomic_fetch_sub</span><span>atomic_fetch_sub_explicit</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_fetch_and"" title=""cpp/atomic/atomic fetch and""><span class=""t-lines""><span>atomic_fetch_and</span><span>atomic_fetch_and_explicit</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_fetch_or"" title=""cpp/atomic/atomic fetch or""><span class=""t-lines""><span>atomic_fetch_or</span><span>atomic_fetch_or_explicit</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_fetch_xor"" title=""cpp/atomic/atomic fetch xor""><span class=""t-lines""><span>atomic_fetch_xor</span><span>atomic_fetch_xor_explicit</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_is_lock_free"" title=""cpp/atomic/atomic is lock free""><span class=""t-lines""><span>atomic_is_lock_free</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_wait"" title=""cpp/atomic/atomic wait""><span class=""t-lines""><span>atomic_wait</span><span>atomic_wait_explicit</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_notify_one"" title=""cpp/atomic/atomic notify one""><span class=""t-lines""><span>atomic_notify_one</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_notify_all"" title=""cpp/atomic/atomic notify all""><span class=""t-lines""><span>atomic_notify_all</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div></td></tr>
<tr class=""t-nv-h1""><td colspan=""5""> Atomic flags</td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_flag"" title=""cpp/atomic/atomic flag""><span class=""t-lines""><span>atomic_flag</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_flag_test_and_set"" title=""cpp/atomic/atomic flag test and set""><span class=""t-lines""><span>atomic_flag_test_and_set</span><span>atomic_flag_test_and_set_explicit</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_flag_clear"" title=""cpp/atomic/atomic flag clear""><span class=""t-lines""><span>atomic_flag_clear</span><span>atomic_flag_clear_explicit</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_flag_test"" title=""cpp/atomic/atomic flag test""><span class=""t-lines""><span>atomic_flag_test</span><span>atomic_flag_test_explicit</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_flag_wait"" title=""cpp/atomic/atomic flag wait""><span class=""t-lines""><span>atomic_flag_wait</span><span>atomic_flag_wait_explicit</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_flag_notify_one"" title=""cpp/atomic/atomic flag notify one""><span class=""t-lines""><span>atomic_flag_notify_one</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_flag_notify_all"" title=""cpp/atomic/atomic flag notify all""><span class=""t-lines""><span>atomic_flag_notify_all</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div></td></tr>
<tr class=""t-nv-h1""><td colspan=""5""> Initialization</td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_init"" title=""cpp/atomic/atomic init""><span class=""t-lines""><span>atomic_init</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span><span class=""t-mark-rev t-deprecated-cxx20"">(deprecated in C++20)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/ATOMIC_VAR_INIT"" title=""cpp/atomic/ATOMIC VAR INIT""><span class=""t-lines""><span>ATOMIC_VAR_INIT</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span><span class=""t-mark-rev t-deprecated-cxx20"">(deprecated in C++20)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/ATOMIC_FLAG_INIT"" title=""cpp/atomic/ATOMIC FLAG INIT""><span class=""t-lines""><span>ATOMIC_FLAG_INIT</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span><span class=""t-mark-rev t-deprecated-cxx20"">(deprecated in C++20)</span></span></span></div></div></td></tr>
<tr class=""t-nv-h1""><td colspan=""5""> Memory ordering</td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/memory_order"" title=""cpp/atomic/memory order""><span class=""t-lines""><span>memory_order</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/kill_dependency"" title=""cpp/atomic/kill dependency""><span class=""t-lines""><span>kill_dependency</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_thread_fence"" title=""cpp/atomic/atomic thread fence""><span class=""t-lines""><span>atomic_thread_fence</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic_signal_fence"" title=""cpp/atomic/atomic signal fence""><span class=""t-lines""><span>atomic_signal_fence</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div></td></tr>
</table></div><div><span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/navbar_content&amp;action=edit"">&#91;edit&#93;</a></span></div></div></div></div><div class=""t-navbar-sep"">&#160;</div><div class=""t-navbar-head""><strong class=""selflink""><tt>std::atomic</tt></strong><div class=""t-navbar-menu""><div><div><table class=""t-nv-begin"" cellpadding=""0"" style="""">
<tr class=""t-nv-h1""><td colspan=""5""> Member functions</td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/atomic"" title=""cpp/atomic/atomic/atomic""><span class=""t-lines""><span>atomic::atomic</span></span></a></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/operator%3D"" title=""cpp/atomic/atomic/operator=""><span class=""t-lines""><span>atomic::operator=</span></span></a></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/is_lock_free"" title=""cpp/atomic/atomic/is lock free""><span class=""t-lines""><span>atomic::is_lock_free</span></span></a></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/store"" title=""cpp/atomic/atomic/store""><span class=""t-lines""><span>atomic::store</span></span></a></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/load"" title=""cpp/atomic/atomic/load""><span class=""t-lines""><span>atomic::load</span></span></a></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/operator_T"" title=""cpp/atomic/atomic/operator T""><span class=""t-lines""><span>atomic::operator T</span></span></a></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/exchange"" title=""cpp/atomic/atomic/exchange""><span class=""t-lines""><span>atomic::exchange</span></span></a></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/compare_exchange"" title=""cpp/atomic/atomic/compare exchange""><span class=""t-lines""><span>atomic::compare_exchange_strong</span><span>atomic::compare_exchange_weak</span></span></a></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/wait"" title=""cpp/atomic/atomic/wait""><span class=""t-lines""><span>atomic::wait</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/notify_one"" title=""cpp/atomic/atomic/notify one""><span class=""t-lines""><span>atomic::notify_one</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/notify_all"" title=""cpp/atomic/atomic/notify all""><span class=""t-lines""><span>atomic::notify_all</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div></td></tr>
<tr class=""t-nv-h1""><td colspan=""5""> Constants </td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/is_always_lock_free"" title=""cpp/atomic/atomic/is always lock free""><span class=""t-lines""><span>atomic::is_always_lock_free</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx17"">(C++17)</span></span></span></div></div></td></tr>
<tr class=""t-nv-h1""><td colspan=""5""> Specialized member functions</td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/fetch_add"" title=""cpp/atomic/atomic/fetch add""><span class=""t-lines""><span>atomic::fetch_add</span></span></a></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/fetch_sub"" title=""cpp/atomic/atomic/fetch sub""><span class=""t-lines""><span>atomic::fetch_sub</span></span></a></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/fetch_and"" title=""cpp/atomic/atomic/fetch and""><span class=""t-lines""><span>atomic::fetch_and</span></span></a></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/fetch_or"" title=""cpp/atomic/atomic/fetch or""><span class=""t-lines""><span>atomic::fetch_or</span></span></a></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/fetch_xor"" title=""cpp/atomic/atomic/fetch xor""><span class=""t-lines""><span>atomic::fetch_xor</span></span></a></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/operator_arith"" title=""cpp/atomic/atomic/operator arith""><span class=""t-lines""><span>atomic::operator++</span><span>atomic::operator++(int)</span><span>atomic::operator--</span><span>atomic::operator--(int)</span></span></a></div></div></td></tr>
<tr class=""t-nv""><td colspan=""5""><div class=""t-nv-ln-table""><div><a href=""/w/cpp/atomic/atomic/operator_arith2"" title=""cpp/atomic/atomic/operator arith2""><span class=""t-lines""><span>atomic::operator+=</span><span>atomic::operator-=</span><span>atomic::operator&amp;=</span><span>atomic::operator|=</span><span>atomic::operator^=</span></span></a></div></div></td></tr>
</table></div><div><span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/navbar_content&amp;action=edit"">&#91;edit&#93;</a></span></div></div></div></div><div class=""t-navbar-sep"">&#160;</div></div>
<table class=""t-dcl-begin""><tbody>
<tr class=""t-dsc-header"">
<td> <div>Defined in header <code><a href=""/w/cpp/header/atomic"" title=""cpp/header/atomic"">&lt;atomic&gt;</a></code>
 </div></td>
<td></td>
<td></td>
</tr>
<tr class=""t-dcl t-since-cxx11"">
<td> <div><span class=""mw-geshi cpp source-cpp""><span class=""kw1"">template</span><span class=""sy1"">&lt;</span> <span class=""kw1"">class</span> T <span class=""sy1"">&gt;</span><br />
<span class=""kw1"">struct</span> atomic<span class=""sy4"">;</span></span></div></td>
<td> (1) </td>
<td> <span class=""t-mark-rev t-since-cxx11"">(since C++11)</span> </td>
</tr>
<tr class=""t-dcl t-since-cxx11"">
<td> <div><span class=""mw-geshi cpp source-cpp""><span class=""kw1"">template</span><span class=""sy1"">&lt;</span> <span class=""kw1"">class</span> U <span class=""sy1"">&gt;</span><br />
<span class=""kw1"">struct</span> atomic<span class=""sy1"">&lt;</span>U<span class=""sy2"">*</span><span class=""sy1"">&gt;</span><span class=""sy4"">;</span></span></div></td>
<td> (2) </td>
<td> <span class=""t-mark-rev t-since-cxx11"">(since C++11)</span> </td>
</tr>
<tr class=""t-dsc-header"">
<td> <div>Defined in header <code><a href=""/w/cpp/header/memory"" title=""cpp/header/memory"">&lt;memory&gt;</a></code>
 </div></td>
<td></td>
<td></td>
</tr>
<tr class=""t-dcl t-since-cxx20"">
<td> <div><span class=""mw-geshi cpp source-cpp""><span class=""kw1"">template</span><span class=""sy1"">&lt;</span> <span class=""kw1"">class</span> U <span class=""sy1"">&gt;</span><br />
<span class=""kw1"">struct</span> atomic<span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/memory/shared_ptr""><span class=""kw730"">std::<span class=""me2"">shared_ptr</span></span></a><span class=""sy1"">&lt;</span>U<span class=""sy1"">&gt;&gt;</span><span class=""sy4"">;</span></span></div></td>
<td> (3) </td>
<td> <span class=""t-mark-rev t-since-cxx20"">(since C++20)</span> </td>
</tr>
<tr class=""t-dcl t-since-cxx20"">
<td> <div><span class=""mw-geshi cpp source-cpp""><span class=""kw1"">template</span><span class=""sy1"">&lt;</span> <span class=""kw1"">class</span> U <span class=""sy1"">&gt;</span><br />
<span class=""kw1"">struct</span> atomic<span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/memory/weak_ptr""><span class=""kw737"">std::<span class=""me2"">weak_ptr</span></span></a><span class=""sy1"">&lt;</span>U<span class=""sy1"">&gt;&gt;</span><span class=""sy4"">;</span></span></div></td>
<td> (4) </td>
<td> <span class=""t-mark-rev t-since-cxx20"">(since C++20)</span> </td>
</tr>
<tr class=""t-dsc-header"">
<td> <div>Defined in header <code><a href=""/w/cpp/header/stdatomic.h"" title=""cpp/header/stdatomic.h"">&lt;stdatomic.h&gt;</a></code>
 </div></td>
<td></td>
<td></td>
</tr>
<tr class=""t-dcl t-since-cxx23"">
<td> <div><span class=""mw-geshi cpp source-cpp""><span class=""co2"">#define _Atomic(T) /* see below */</span></span></div></td>
<td> (5) </td>
<td> <span class=""t-mark-rev t-since-cxx23"">(since C++23)</span> </td>
</tr>
<tr class=""t-dcl-sep""><td></td><td></td><td></td></tr>
</tbody></table>
<p>Each instantiation and full specialization of the <code>std::atomic</code> template defines an atomic type. If one thread writes to an atomic object while another thread reads from it, the behavior is well-defined (see <a href=""/w/cpp/language/memory_model"" title=""cpp/language/memory model"">memory model</a> for details on data races).
</p><p>In addition, accesses to atomic objects may establish inter-thread synchronization and order non-atomic memory accesses as specified by <span class=""t-lc""><a href=""/w/cpp/atomic/memory_order"" title=""cpp/atomic/memory order"">std::memory_order</a></span>.
</p><p><code>std::atomic</code> is neither copyable nor movable.
</p>
 <table class=""t-rev-begin"">
<tr class=""t-rev t-since-cxx23""><td>
<p>The compatibility macro <code>_Atomic</code> is provided in <a href=""/w/cpp/header/stdatomic.h"" title=""cpp/header/stdatomic.h""><tt>&lt;stdatomic.h&gt;</tt></a> such that <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">_Atomic<span class=""br0"">&#40;</span>T<span class=""br0"">&#41;</span></span></span> is identical to <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span>T<span class=""sy1"">&gt;</span></span></span> while both are well-formed.
</p><p>It is unspecified whether any declaration in namespace <code>std</code> is available when <code>&lt;stdatomic.h&gt;</code> is included.
</p>
</td>
<td><span class=""t-mark-rev t-since-cxx23"">(since C++23)</span></td></tr>
</table>
<table id=""toc"" class=""toc""><tr><td><div id=""toctitle""><h2>Contents</h2></div>
<ul>
<li class=""toclevel-1 tocsection-1""><a href=""#Specializations""><span class=""tocnumber"">1</span> <span class=""toctext"">Specializations</span></a>
<ul>
<li class=""toclevel-2 tocsection-2""><a href=""#Primary_template""><span class=""tocnumber"">1.1</span> <span class=""toctext"">Primary template</span></a></li>
<li class=""toclevel-2 tocsection-3""><a href=""#Partial_specializations""><span class=""tocnumber"">1.2</span> <span class=""toctext"">Partial specializations</span></a></li>
<li class=""toclevel-2 tocsection-4""><a href=""#Specializations_for_integral_types""><span class=""tocnumber"">1.3</span> <span class=""toctext"">Specializations for integral types</span></a></li>
<li class=""toclevel-2""><a href=""#Specializations_for_floating-point_types""><span class=""tocnumber"">1.4</span> <span class=""toctext"">Specializations for floating-point types</span></a></li>
</ul>
</li>
<li class=""toclevel-1 tocsection-6""><a href=""#Type_aliases""><span class=""tocnumber"">2</span> <span class=""toctext"">Type aliases</span></a>
<ul>
<li class=""toclevel-2""><a href=""#Aliases_for_all_std::atomic.3CIntegral.3E""><span class=""tocnumber"">2.1</span> <span class=""toctext"">Aliases for all std::atomic&lt;Integral&gt;</span></a></li>
<li class=""toclevel-2""><a href=""#Aliases_for_special-purpose_types""><span class=""tocnumber"">2.2</span> <span class=""toctext"">Aliases for special-purpose types</span></a></li>
</ul>
</li>
<li class=""toclevel-1 tocsection-7""><a href=""#Member_types""><span class=""tocnumber"">3</span> <span class=""toctext"">Member types</span></a></li>
<li class=""toclevel-1 tocsection-8""><a href=""#Member_functions""><span class=""tocnumber"">4</span> <span class=""toctext"">Member functions</span></a></li>
<li class=""toclevel-1""><a href=""#Constants""><span class=""tocnumber"">5</span> <span class=""toctext"">Constants</span></a></li>
<li class=""toclevel-1 tocsection-9""><a href=""#Specialized_member_functions""><span class=""tocnumber"">6</span> <span class=""toctext"">Specialized member functions</span></a></li>
<li class=""toclevel-1 tocsection-10""><a href=""#Notes""><span class=""tocnumber"">7</span> <span class=""toctext"">Notes</span></a></li>
<li class=""toclevel-1 tocsection-11""><a href=""#Defect_reports""><span class=""tocnumber"">8</span> <span class=""toctext"">Defect reports</span></a></li>
<li class=""toclevel-1 tocsection-12""><a href=""#See_also""><span class=""tocnumber"">9</span> <span class=""toctext"">See also</span></a></li>
</ul>
</td></tr></table>
<h3><span class=""editsection"">[<a href=""/mwiki/index.php?title=cpp/atomic/atomic&amp;action=edit&amp;section=1"" title=""Edit section: Specializations"">edit</a>]</span> <span class=""mw-headline"" id=""Specializations""> Specializations </span></h3>
<h4><span class=""editsection"">[<a href=""/mwiki/index.php?title=cpp/atomic/atomic&amp;action=edit&amp;section=2"" title=""Edit section: Primary template"">edit</a>]</span> <span class=""mw-headline"" id=""Primary_template"">Primary template</span></h4>
<p>The primary <code>std::atomic</code> template may be instantiated with any <a href=""/w/cpp/named_req/TriviallyCopyable"" title=""cpp/named req/TriviallyCopyable""><span style=""font-family: Georgia, &#39;DejaVu Serif&#39;, serif; font-style:italic"">TriviallyCopyable</span></a> type <code>T</code> satisfying both <a href=""/w/cpp/named_req/CopyConstructible"" title=""cpp/named req/CopyConstructible""><span style=""font-family: Georgia, &#39;DejaVu Serif&#39;, serif; font-style:italic"">CopyConstructible</span></a> and <a href=""/w/cpp/named_req/CopyAssignable"" title=""cpp/named req/CopyAssignable""><span style=""font-family: Georgia, &#39;DejaVu Serif&#39;, serif; font-style:italic"">CopyAssignable</span></a>. The program is ill-formed if any of following values is <code>false</code>:
</p>
<ul><li> <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><a href=""http://en.cppreference.com/w/cpp/types/is_trivially_copyable""><span class=""kw501"">std::<span class=""me2"">is_trivially_copyable</span></span></a><span class=""sy1"">&lt;</span>T<span class=""sy1"">&gt;</span><span class=""sy4"">::</span><span class=""me2"">value</span></span></span>
</li><li> <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><a href=""http://en.cppreference.com/w/cpp/types/is_copy_constructible""><span class=""kw533"">std::<span class=""me2"">is_copy_constructible</span></span></a><span class=""sy1"">&lt;</span>T<span class=""sy1"">&gt;</span><span class=""sy4"">::</span><span class=""me2"">value</span></span></span>
</li><li> <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><a href=""http://en.cppreference.com/w/cpp/types/is_move_constructible""><span class=""kw539"">std::<span class=""me2"">is_move_constructible</span></span></a><span class=""sy1"">&lt;</span>T<span class=""sy1"">&gt;</span><span class=""sy4"">::</span><span class=""me2"">value</span></span></span>
</li><li> <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><a href=""http://en.cppreference.com/w/cpp/types/is_copy_assignable""><span class=""kw551"">std::<span class=""me2"">is_copy_assignable</span></span></a><span class=""sy1"">&lt;</span>T<span class=""sy1"">&gt;</span><span class=""sy4"">::</span><span class=""me2"">value</span></span></span>
</li><li> <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><a href=""http://en.cppreference.com/w/cpp/types/is_move_assignable""><span class=""kw557"">std::<span class=""me2"">is_move_assignable</span></span></a><span class=""sy1"">&lt;</span>T<span class=""sy1"">&gt;</span><span class=""sy4"">::</span><span class=""me2"">value</span></span></span>
</li></ul>
<div dir=""ltr"" class=""mw-geshi"" style=""text-align: left;""><div class=""cpp source-cpp""><pre class=""de1""><span class=""kw1"">struct</span> Counters <span class=""br0"">&#123;</span> <span class=""kw4"">int</span> a<span class=""sy4"">;</span> <span class=""kw4"">int</span> b<span class=""sy4"">;</span> <span class=""br0"">&#125;</span><span class=""sy4"">;</span> <span class=""co1"">// user-defined trivially-copyable type</span>
std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span>Counters<span class=""sy1"">&gt;</span> cnt<span class=""sy4"">;</span>         <span class=""co1"">// specialization for the user-defined type</span></pre></div></div>
<p><span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><span class=""kw4"">bool</span><span class=""sy1"">&gt;</span></span></span> uses the primary template. It is guaranteed to be a standard layout struct.
</p>
<h4><span class=""editsection"">[<a href=""/mwiki/index.php?title=cpp/atomic/atomic&amp;action=edit&amp;section=3"" title=""Edit section: Partial specializations"">edit</a>]</span> <span class=""mw-headline"" id=""Partial_specializations"">Partial specializations</span></h4>
<p>The standard library provides partial specializations of the <code>std::atomic</code> template for the following types with additional properties that the primary template does not have: 
</p><p>2) Partial specializations <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span>U<span class=""sy2"">*</span><span class=""sy1"">&gt;</span></span></span> for all pointer types. These specializations have standard layout<span class=""t-rev-inl t-until-cxx20""><span>, trivial default constructors,</span> <span><span class=""t-mark-rev t-until-cxx20"">(until C++20)</span></span></span> and trivial destructors. Besides the operations provided for all atomic types, these specializations additionally support atomic arithmetic operations appropriate to pointer types, such as <a href=""/w/cpp/atomic/atomic/fetch_add"" title=""cpp/atomic/atomic/fetch add""><code>fetch_add</code></a>, <a href=""/w/cpp/atomic/atomic/fetch_sub"" title=""cpp/atomic/atomic/fetch sub""><code>fetch_sub</code></a>.
</p>
 <table class=""t-rev-begin"">
<tr class=""t-rev t-since-cxx20""><td>
<p>3-4) Partial specializations <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/memory/shared_ptr""><span class=""kw730"">std::<span class=""me2"">shared_ptr</span></span></a><span class=""sy1"">&lt;</span>U<span class=""sy1"">&gt;&gt;</span></span></span> and <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/memory/weak_ptr""><span class=""kw737"">std::<span class=""me2"">weak_ptr</span></span></a><span class=""sy1"">&lt;</span>U<span class=""sy1"">&gt;&gt;</span></span></span> are provided for <span class=""t-lc""><a href=""/w/cpp/memory/shared_ptr"" title=""cpp/memory/shared ptr"">std::shared_ptr</a></span> and <span class=""t-lc""><a href=""/w/cpp/memory/weak_ptr"" title=""cpp/memory/weak ptr"">std::weak_ptr</a></span>.
</p><p>See <a href=""/w/cpp/memory/shared_ptr/atomic2"" title=""cpp/memory/shared ptr/atomic2"">std::atomic<span class=""t-dsc-small"">&lt;std::shared_ptr&gt;</span></a> and <a href=""/w/cpp/memory/weak_ptr/atomic2"" title=""cpp/memory/weak ptr/atomic2"">std::atomic<span class=""t-dsc-small"">&lt;std::weak_ptr&gt;</span></a> for details.
</p>
</td>
<td><span class=""t-mark-rev t-since-cxx20"">(since C++20)</span></td></tr>
</table>
<h4><span class=""editsection"">[<a href=""/mwiki/index.php?title=cpp/atomic/atomic&amp;action=edit&amp;section=4"" title=""Edit section: Specializations for integral types"">edit</a>]</span> <span class=""mw-headline"" id=""Specializations_for_integral_types""> Specializations for integral types </span></h4>
<p>When instantiated with one of the following integral types, <code>std::atomic</code> provides additional atomic operations appropriate to integral types such as <a href=""/w/cpp/atomic/atomic/fetch_add"" title=""cpp/atomic/atomic/fetch add""><code>fetch_add</code></a>, <a href=""/w/cpp/atomic/atomic/fetch_sub"" title=""cpp/atomic/atomic/fetch sub""><code>fetch_sub</code></a>, <a href=""/w/cpp/atomic/atomic/fetch_and"" title=""cpp/atomic/atomic/fetch and""><code>fetch_and</code></a>, <a href=""/w/cpp/atomic/atomic/fetch_or"" title=""cpp/atomic/atomic/fetch or""><code>fetch_or</code></a>, <a href=""/w/cpp/atomic/atomic/fetch_xor"" title=""cpp/atomic/atomic/fetch xor""><code>fetch_xor</code></a>:
</p>
<dl><dd><ul><li> The character types <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><span class=""kw4"">char</span></span></span><span class=""t-rev-inl t-since-cxx20""><span>, <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">char8_t</span></span></span> <span><span class=""t-mark-rev t-since-cxx20"">(since C++20)</span></span></span>, <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><span class=""kw4"">char16_t</span></span></span>, <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><span class=""kw4"">char32_t</span></span></span>, and <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><span class=""kw4"">wchar_t</span></span></span>;
</li><li> The standard signed integer types: <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><span class=""kw4"">signed</span> <span class=""kw4"">char</span></span></span>, <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><span class=""kw4"">short</span></span></span>, <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><span class=""kw4"">int</span></span></span>, <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><span class=""kw4"">long</span></span></span>, and <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><span class=""kw4"">long</span> <span class=""kw4"">long</span></span></span>;
</li><li> The standard unsigned integer types: <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><span class=""kw4"">unsigned</span> <span class=""kw4"">char</span></span></span>, <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><span class=""kw4"">unsigned</span> <span class=""kw4"">short</span></span></span>, <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><span class=""kw4"">unsigned</span> <span class=""kw4"">int</span></span></span>, <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><span class=""kw4"">unsigned</span> <span class=""kw4"">long</span></span></span>, and <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><span class=""kw4"">unsigned</span> <span class=""kw4"">long</span> <span class=""kw4"">long</span></span></span>;
</li><li> Any additional integral types needed by the typedefs in the header <a href=""/w/cpp/header/cstdint"" title=""cpp/header/cstdint""><tt>&lt;cstdint&gt;</tt></a>.
</li></ul>
</dd></dl>
<p>Additionally, the resulting <code>std::atomic&lt;<i>Integral</i>&gt;</code> specialization has standard layout<span class=""t-rev-inl t-until-cxx20""><span>, a trivial default constructor,</span> <span><span class=""t-mark-rev t-until-cxx20"">(until C++20)</span></span></span> and a trivial destructor. Signed integer arithmetic is defined to use two's complement; there are no undefined results.
</p>
 <table class=""t-rev-begin"">
<tr class=""t-rev t-since-cxx20""><td>
<h4> <span class=""mw-headline"" id=""Specializations_for_floating-point_types""> Specializations for floating-point types </span></h4>
<p>When instantiated with one of the floating-point types <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><span class=""kw4"">float</span></span></span>, <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><span class=""kw4"">double</span></span></span>, and <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><span class=""kw4"">long</span> <span class=""kw4"">double</span></span></span>, <code>std::atomic</code> provides additional atomic operations appropriate to floating-point types such as <a href=""/w/cpp/atomic/atomic/fetch_add"" title=""cpp/atomic/atomic/fetch add""><code>fetch_add</code></a> and <a href=""/w/cpp/atomic/atomic/fetch_sub"" title=""cpp/atomic/atomic/fetch sub""><code>fetch_sub</code></a>.
</p><p>Additionally, the resulting <code>std::atomic&lt;<i>Floating</i>&gt;</code> specialization has standard layout and a trivial destructor.
</p><p>No operations result in undefined behavior even if the result is not representable in the floating-point type. The <a href=""/w/cpp/numeric/fenv"" title=""cpp/numeric/fenv"">floating-point environment</a> in effect may be different from the calling thread's floating-point environment.
</p>
</td>
<td><span class=""t-mark-rev t-since-cxx20"">(since C++20)</span></td></tr>
</table>
<h3><span class=""editsection"">[<a href=""/mwiki/index.php?title=cpp/atomic/atomic&amp;action=edit&amp;section=6"" title=""Edit section: Type aliases"">edit</a>]</span> <span class=""mw-headline"" id=""Type_aliases""> Type aliases </span></h3>
<p>Type aliases are provided for <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><span class=""kw4"">bool</span></span></span> and all integral types listed above, as follows:
</p>
<table class=""t-dsc-begin"">

<tr>
<td colspan=""2""> <h5> <span class=""mw-headline"" id=""Aliases_for_all_std::atomic.3CIntegral.3E"">  Aliases for all <code>std::atomic&lt;Integral&gt;</code> </span></h5>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_bool</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><span class=""kw4"">bool</span><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_char</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><span class=""kw4"">char</span><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_schar</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><span class=""kw4"">signed</span> <span class=""kw4"">char</span><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_uchar</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><span class=""kw4"">unsigned</span> <span class=""kw4"">char</span><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_short</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><span class=""kw4"">short</span><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_ushort</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><span class=""kw4"">unsigned</span> <span class=""kw4"">short</span><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_int</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><span class=""kw4"">int</span><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_uint</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><span class=""kw4"">unsigned</span> <span class=""kw4"">int</span><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_long</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><span class=""kw4"">long</span><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_ulong</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><span class=""kw4"">unsigned</span> <span class=""kw4"">long</span><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_llong</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><span class=""kw4"">long</span> <span class=""kw4"">long</span><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_ullong</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><span class=""kw4"">unsigned</span> <span class=""kw4"">long</span> <span class=""kw4"">long</span><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_char8_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span>char8_t<span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_char16_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><span class=""kw4"">char16_t</span><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_char32_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><span class=""kw4"">char32_t</span><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_wchar_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><span class=""kw4"">wchar_t</span><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_int8_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span><span class=""t-mark"">(optional)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw107"">std::<span class=""me2"">int8_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_uint8_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span><span class=""t-mark"">(optional)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw121"">std::<span class=""me2"">uint8_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_int16_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span><span class=""t-mark"">(optional)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw108"">std::<span class=""me2"">int16_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_uint16_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span><span class=""t-mark"">(optional)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw122"">std::<span class=""me2"">uint16_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_int32_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span><span class=""t-mark"">(optional)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw109"">std::<span class=""me2"">int32_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_uint32_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span><span class=""t-mark"">(optional)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw123"">std::<span class=""me2"">uint32_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_int64_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span><span class=""t-mark"">(optional)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw110"">std::<span class=""me2"">int64_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_uint64_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span><span class=""t-mark"">(optional)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw124"">std::<span class=""me2"">uint64_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_int_least8_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw115"">std::<span class=""me2"">int_least8_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_uint_least8_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw129"">std::<span class=""me2"">uint_least8_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_int_least16_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw116"">std::<span class=""me2"">int_least16_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_uint_least16_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw130"">std::<span class=""me2"">uint_least16_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_int_least32_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw117"">std::<span class=""me2"">int_least32_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_uint_least32_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw131"">std::<span class=""me2"">uint_least32_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_int_least64_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw118"">std::<span class=""me2"">int_least64_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_uint_least64_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw132"">std::<span class=""me2"">uint_least64_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_int_fast8_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw111"">std::<span class=""me2"">int_fast8_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_uint_fast8_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw125"">std::<span class=""me2"">uint_fast8_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_int_fast16_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw112"">std::<span class=""me2"">int_fast16_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_uint_fast16_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw126"">std::<span class=""me2"">uint_fast16_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_int_fast32_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw113"">std::<span class=""me2"">int_fast32_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_uint_fast32_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw127"">std::<span class=""me2"">uint_fast32_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_int_fast64_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw114"">std::<span class=""me2"">int_fast64_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_uint_fast64_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw128"">std::<span class=""me2"">uint_fast64_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_intptr_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span><span class=""t-mark"">(optional)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw120"">std::<span class=""me2"">intptr_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_uintptr_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span><span class=""t-mark"">(optional)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw134"">std::<span class=""me2"">uintptr_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_size_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/size_t""><span class=""kw101"">std::<span class=""me2"">size_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_ptrdiff_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/ptrdiff_t""><span class=""kw102"">std::<span class=""me2"">ptrdiff_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_intmax_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw119"">std::<span class=""me2"">intmax_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_uintmax_t</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span><a href=""http://en.cppreference.com/w/cpp/types/integer""><span class=""kw133"">std::<span class=""me2"">uintmax_t</span></span></a><span class=""sy1"">&gt;</span></span></span>  <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_integral_types&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr>
<td colspan=""2""> <h5> <span class=""mw-headline"" id=""Aliases_for_special-purpose_types"">  Aliases for special-purpose types </span></h5>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_signed_lock_free</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div>
</td>
<td>   a signed integral atomic type that is lock-free and for which waiting/notifying is most efficient <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_lock_free_aliases&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>


<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><strong class=""selflink""> <span class=""t-lines""><span>atomic_unsigned_lock_free</span></span></strong></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div>
</td>
<td>   a unsigned integral atomic type that is lock-free and for which waiting/notifying is most efficient <br /> <span class=""t-mark"">(typedef)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_atomic_lock_free_aliases&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>
</table>
Note: <code>std::atomic_int<i>N</i>_t</code>, <code>std::atomic_uint<i>N</i>_t</code>, <code>std::atomic_intptr_t</code>, and <code>atomic_uintptr_t</code> are defined if and only if <code>std::int<i>N</i>_t</code>, <code>std::uint<i>N</i>_t</code>, <code>std::intptr_t</code>, and <code>std::uintptr_t</code> are defined, respectively.  <table class=""t-rev-begin"">
<tr class=""t-rev t-since-cxx20""><td>
<p><code>std::atomic_signed_lock_free</code> and <code>std::atomic_unsigned_lock_free</code> are optional in freestanding implementations.
</p>
</td>
<td><span class=""t-mark-rev t-since-cxx20"">(since C++20)</span></td></tr>
</table>
<h3><span class=""editsection"">[<a href=""/mwiki/index.php?title=cpp/atomic/atomic&amp;action=edit&amp;section=7"" title=""Edit section: Member types"">edit</a>]</span> <span class=""mw-headline"" id=""Member_types"">Member types</span></h3>
<table class=""t-dsc-begin"">

<tr class=""t-dsc-hitem"">
<td>  Member type
</td>
<td>  Definition
</td></tr>


<tr class=""t-dsc"">
<td>  <code>value_type</code>
</td>
<td>  <code>T</code> <span class=""t-mark"">(regardless of whether specialized or not)</span>
</td></tr>


<tr class=""t-dsc"">
<td>  <code>difference_type</code>
</td>
<td>  <code>value_type</code> <span class=""t-mark"">(only for <code>atomic&lt;<i>Integral</i>&gt;</code> <span class=""t-rev-inl t-since-cxx20""><span>and <code>atomic&lt;<i>Floating</i>&gt;</code></span> <span><span class=""t-mark-rev t-since-cxx20"">(since C++20)</span></span></span> specializations)</span><br /> <span class=""t-lc""><a href=""/w/cpp/types/ptrdiff_t"" title=""cpp/types/ptrdiff t"">std::ptrdiff_t</a></span> <span class=""t-mark"">(only for <code>atomic&lt;U*&gt;</code> specializations)</span>
</td></tr>

</table>
<p><code>difference_type</code> is not defined in the primary <code>atomic</code> template or in the partial specializations for <span class=""t-lc""><a href=""/w/cpp/memory/shared_ptr"" title=""cpp/memory/shared ptr"">std::shared_ptr</a></span> and <span class=""t-lc""><a href=""/w/cpp/memory/weak_ptr"" title=""cpp/memory/weak ptr"">std::weak_ptr</a></span>.
</p>
<h3><span class=""editsection"">[<a href=""/mwiki/index.php?title=cpp/atomic/atomic&amp;action=edit&amp;section=8"" title=""Edit section: Member functions"">edit</a>]</span> <span class=""mw-headline"" id=""Member_functions"">Member functions</span></h3>
<table class=""t-dsc-begin"">

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div t-dsc-member-nobold-div""><div><a href=""/w/cpp/atomic/atomic/atomic"" title=""cpp/atomic/atomic/atomic""> <span class=""t-lines""><span>(constructor)</span></span></a></div></div>
</td>
<td>  constructs an atomic object <br /> <span class=""t-mark"">(public member function)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_constructor&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic/operator%3D"" title=""cpp/atomic/atomic/operator=""> <span class=""t-lines""><span>operator=</span></span></a></div></div>
</td>
<td>   stores a value into an atomic object <br /> <span class=""t-mark"">(public member function)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_operator%3D&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic/is_lock_free"" title=""cpp/atomic/atomic/is lock free""> <span class=""t-lines""><span>is_lock_free</span></span></a></div></div>
</td>
<td>   checks if the atomic object is lock-free <br /> <span class=""t-mark"">(public member function)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_is_lock_free&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic/store"" title=""cpp/atomic/atomic/store""> <span class=""t-lines""><span>store</span></span></a></div></div>
</td>
<td>   atomically replaces the value of the atomic object with a non-atomic argument  <br /> <span class=""t-mark"">(public member function)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_store&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic/load"" title=""cpp/atomic/atomic/load""> <span class=""t-lines""><span>load</span></span></a></div></div>
</td>
<td>   atomically obtains the value of the atomic object  <br /> <span class=""t-mark"">(public member function)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_load&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic/operator_T"" title=""cpp/atomic/atomic/operator T""> <span class=""t-lines""><span>operator T</span></span></a></div></div>
</td>
<td>   loads a value from an atomic object  <br /> <span class=""t-mark"">(public member function)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_operator_T&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic/exchange"" title=""cpp/atomic/atomic/exchange""> <span class=""t-lines""><span>exchange</span></span></a></div></div>
</td>
<td>   atomically replaces the value of the atomic object and obtains the value held previously <br /> <span class=""t-mark"">(public member function)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_exchange&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic/compare_exchange"" title=""cpp/atomic/atomic/compare exchange""> <span class=""t-lines""><span>compare_exchange_weak</span><span>compare_exchange_strong</span></span></a></div></div>
</td>
<td>   atomically compares the value of the atomic object with non-atomic argument and performs atomic exchange if equal or atomic load if not  <br /> <span class=""t-mark"">(public member function)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_compare_exchange&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic/wait"" title=""cpp/atomic/atomic/wait""> <span class=""t-lines""><span>wait</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div>
</td>
<td>   blocks the thread until notified and the atomic value changes  <br /> <span class=""t-mark"">(public member function)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_wait&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic/notify_one"" title=""cpp/atomic/atomic/notify one""> <span class=""t-lines""><span>notify_one</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div>
</td>
<td>   notifies at least one thread waiting on the atomic object  <br /> <span class=""t-mark"">(public member function)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_notify_one&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic/notify_all"" title=""cpp/atomic/atomic/notify all""> <span class=""t-lines""><span>notify_all</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div>
</td>
<td>   notifies all threads blocked waiting on the atomic object  <br /> <span class=""t-mark"">(public member function)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_notify_all&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr>
<td colspan=""2""> <h3> <span class=""mw-headline"" id=""Constants""> Constants</span></h3>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic/is_always_lock_free"" title=""cpp/atomic/atomic/is always lock free""> <span class=""t-lines""><span>is_always_lock_free</span></span></a></div><div><span class=""t-lines""><span><span class=""t-cmark"">[static]</span> <span class=""t-mark-rev t-since-cxx17"">(C++17)</span></span></span></div></div>
</td>
<td>   indicates that the type is always lock-free <br /> <span class=""t-mark"">(public static member constant)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_is_always_lock_free&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>
</table>
<h3><span class=""editsection"">[<a href=""/mwiki/index.php?title=cpp/atomic/atomic&amp;action=edit&amp;section=9"" title=""Edit section: Specialized member functions"">edit</a>]</span> <span class=""mw-headline"" id=""Specialized_member_functions"">Specialized member functions</span></h3>
<table class=""t-dsc-begin"">

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic/fetch_add"" title=""cpp/atomic/atomic/fetch add""> <span class=""t-lines""><span>fetch_add</span></span></a></div></div>
</td>
<td>   atomically adds the argument to the value stored in the atomic object and obtains the value held previously  <br /> <span class=""t-mark"">(public member function)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_fetch_add&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic/fetch_sub"" title=""cpp/atomic/atomic/fetch sub""> <span class=""t-lines""><span>fetch_sub</span></span></a></div></div>
</td>
<td>   atomically subtracts the argument from the value stored in the atomic object and obtains the value held previously  <br /> <span class=""t-mark"">(public member function)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_fetch_sub&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic/fetch_and"" title=""cpp/atomic/atomic/fetch and""> <span class=""t-lines""><span>fetch_and</span></span></a></div></div>
</td>
<td>   atomically performs bitwise AND between the argument and the value of the atomic object and obtains the value held previously  <br /> <span class=""t-mark"">(public member function)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_fetch_and&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic/fetch_or"" title=""cpp/atomic/atomic/fetch or""> <span class=""t-lines""><span>fetch_or</span></span></a></div></div>
</td>
<td>   atomically performs bitwise OR between the argument and the value of the atomic object and obtains the value held previously  <br /> <span class=""t-mark"">(public member function)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_fetch_or&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic/fetch_xor"" title=""cpp/atomic/atomic/fetch xor""> <span class=""t-lines""><span>fetch_xor</span></span></a></div></div>
</td>
<td>   atomically performs bitwise XOR between the argument and the value of the atomic object and obtains the value held previously  <br /> <span class=""t-mark"">(public member function)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_fetch_xor&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic/operator_arith"" title=""cpp/atomic/atomic/operator arith""> <span class=""t-lines""><span>operator++</span><span>operator++<span class=""t-dsc-small"">(int)</span></span><span>operator--</span><span>operator--<span class=""t-dsc-small"">(int)</span></span></span></a></div></div>
</td>
<td>   increments or decrements the atomic value by one  <br /> <span class=""t-mark"">(public member function)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_operator_arith&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic/operator_arith2"" title=""cpp/atomic/atomic/operator arith2""> <span class=""t-lines""><span>operator+=</span><span>operator-=</span><span>operator&amp;=</span><span>operator|=</span><span>operator^=</span></span></a></div></div>
</td>
<td>   adds, subtracts, or performs bitwise AND, OR, XOR with the atomic value <br /> <span class=""t-mark"">(public member function)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/atomic/dsc_operator_arith2&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>
</table>
<h3><span class=""editsection"">[<a href=""/mwiki/index.php?title=cpp/atomic/atomic&amp;action=edit&amp;section=10"" title=""Edit section: Notes"">edit</a>]</span> <span class=""mw-headline"" id=""Notes"">Notes</span></h3>
<p>There are non-member function template equivalents for all member functions of <code>std::atomic</code>. Those non-member functions may be additionally overloaded for types that are not specializations of <code>std::atomic</code>, but are able to guarantee atomicity. The only such type in the standard library is <span class=""t-c""><span class=""mw-geshi cpp source-cpp""><a href=""http://en.cppreference.com/w/cpp/memory/shared_ptr""><span class=""kw730"">std::<span class=""me2"">shared_ptr</span></span></a><span class=""sy1"">&lt;</span>U<span class=""sy1"">&gt;</span></span></span>.
</p><p><code>_Atomic</code> is a <a href=""/w/c/keyword/_Atomic"" title=""c/keyword/ Atomic"">keyword</a> and used to provide <a href=""/w/c/language/atomic"" title=""c/language/atomic"">atomic types</a> in C.
</p><p>Implementations are recommended to ensure that the representation of <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">_Atomic<span class=""br0"">&#40;</span>T<span class=""br0"">&#41;</span></span></span> in C is same as that of <span class=""t-c""><span class=""mw-geshi cpp source-cpp"">std<span class=""sy4"">::</span><span class=""me2"">atomic</span><span class=""sy1"">&lt;</span>T<span class=""sy1"">&gt;</span></span></span> in C++ for every possible type <code>T</code>. The mechanisms used to ensure atomicity and memory ordering should be compatible.
</p><p>On gcc and clang, some of the functionality described here requires linking against <code>-latomic</code>.
</p>
<h3><span class=""editsection"">[<a href=""/mwiki/index.php?title=cpp/atomic/atomic&amp;action=edit&amp;section=11"" title=""Edit section: Defect reports"">edit</a>]</span> <span class=""mw-headline"" id=""Defect_reports"">Defect reports</span></h3>
<p>The following behavior-changing defect reports were applied retroactively to previously published C++ standards.
</p>
<table class=""dsctable"" style=""font-size:0.8em"">
<tr>
<th> DR
</th>
<th> Applied to
</th>
<th> Behavior as published
</th>
<th> Correct behavior
</th></tr>
<tr>
<td> <a rel=""nofollow"" class=""external text"" href=""https://cplusplus.github.io/LWG/issue2441"">LWG 2441</a>
</td>
<td> C++11
</td>
<td> typedefs for atomic versions of optional<br /><a href=""/w/cpp/types/integer"" title=""cpp/types/integer"">fixed width integer types</a> were missing
</td>
<td> added
</td></tr>
<tr>
<td> <a rel=""nofollow"" class=""external text"" href=""https://wg21.link/P0558R1"">P0558R1</a>
</td>
<td> C++11
</td>
<td> template argument deduction for some functions<br />for atomic types might accidently fail;<br />invalid pointer operations were provided
</td>
<td> specification was substantially rewritten:<br />member typedefs <code>value_type</code> and <code>difference_type</code> are added
</td></tr>
<tr>
<td> <a rel=""nofollow"" class=""external text"" href=""https://cplusplus.github.io/LWG/issue3012"">LWG 3012</a>
</td>
<td> C++11
</td>
<td> <code>std::atomic&lt;T&gt;</code> was permitted for<br />any <code>T</code> that is trivially copyable but not copyable
</td>
<td> such specializations are forbidden
</td></tr></table>
<h3><span class=""editsection"">[<a href=""/mwiki/index.php?title=cpp/atomic/atomic&amp;action=edit&amp;section=12"" title=""Edit section: See also"">edit</a>]</span> <span class=""mw-headline"" id=""See_also"">See also</span></h3>
<table class=""t-dsc-begin"">

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/atomic/atomic_flag"" title=""cpp/atomic/atomic flag""> <span class=""t-lines""><span>atomic_flag</span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx11"">(C++11)</span></span></span></div></div>
</td>
<td>   the lock-free boolean atomic type  <br /> <span class=""t-mark"">(class)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/atomic/dsc_atomic_flag&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/memory/shared_ptr/atomic2"" title=""cpp/memory/shared ptr/atomic2""> <span class=""t-lines""><span>std::atomic<span class=""t-dsc-small"">&lt;std::shared_ptr&gt;</span></span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div>
</td>
<td>   atomic shared pointer  <br /> <span class=""t-mark"">(class template specialization)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/memory/shared_ptr/dsc_atomic2&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td>  <div class=""t-dsc-member-div""><div><a href=""/w/cpp/memory/weak_ptr/atomic2"" title=""cpp/memory/weak ptr/atomic2""> <span class=""t-lines""><span>std::atomic<span class=""t-dsc-small"">&lt;std::weak_ptr&gt;</span></span></span></a></div><div><span class=""t-lines""><span><span class=""t-mark-rev t-since-cxx20"">(C++20)</span></span></span></div></div>
</td>
<td>   atomic weak pointer  <br /> <span class=""t-mark"">(class template specialization)</span> <span class=""editsection noprint plainlinks"" title=""Edit this template""><a rel=""nofollow"" class=""external text"" href=""https://en.cppreference.com/mwiki/index.php?title=Template:cpp/memory/weak_ptr/dsc_atomic2&amp;action=edit"">&#91;edit&#93;</a></span>
</td></tr>

<tr class=""t-dsc"">
<td colspan=""2""> <div class=""t-dsc-see""><span><a href=""/w/c/language/atomic"" title=""c/language/atomic"">C documentation</a></span> for <span class=""""><span>Atomic types</span></span></div>
</td></tr>

</table>

<!-- 
NewPP limit report
Preprocessor visited node count: 16087/1000000
Preprocessor generated node count: 17979/1000000
Post‐expand include size: 552963/2097152 bytes
Template argument size: 112455/2097152 bytes
Highest expansion depth: 22/40
Expensive parser function count: 0/100
-->

<!-- Saved in parser cache with key mwiki1-mwiki_en_:pcache:idhash:4734-0!*!0!!en!*!* and timestamp 20201209161237 -->
</div>                    <!-- /bodycontent -->
                                        <!-- printfooter -->
                    <div class=""printfooter"">
                    Retrieved from ""<a href=""https://en.cppreference.com/mwiki/index.php?title=cpp/atomic/atomic&amp;oldid=124339"">https://en.cppreference.com/mwiki/index.php?title=cpp/atomic/atomic&amp;oldid=124339</a>""                    </div>
                    <!-- /printfooter -->
                                                            <!-- catlinks -->
                    <div id='catlinks' class='catlinks catlinks-allhidden'></div>                    <!-- /catlinks -->
                                                            <div class=""visualClear""></div>
                    <!-- debughtml -->
                                        <!-- /debughtml -->
                </div>
                <!-- /bodyContent -->
            </div>
        </div>
        <!-- /content -->
        <!-- footer -->
        <div id=""cpp-footer-base"" class=""noprint"">
            <div id=""footer"">
                        <div id=""cpp-navigation"">
            <h5>Navigation</h5>
            <ul>
<li id=""n-Support-us""><a href=""http://www.cppreference.com/support"" rel=""nofollow"">Support us</a></li><li id=""n-recentchanges""><a href=""/w/Special:RecentChanges"" title=""A list of recent changes in the wiki [r]"" accesskey=""r"">Recent changes</a></li><li id=""n-FAQ""><a href=""/w/Cppreference:FAQ"">FAQ</a></li><li id=""n-Offline-version""><a href=""/w/Cppreference:Archives"">Offline version</a></li>            </ul>
        </div>
                        <div id=""cpp-toolbox"">
            <h5><span>Toolbox</span><a href=""#""></a></h5>
            <ul>
<li id=""t-whatlinkshere""><a href=""/w/Special:WhatLinksHere/cpp/atomic/atomic"" title=""A list of all wiki pages that link here [j]"" accesskey=""j"">What links here</a></li><li id=""t-recentchangeslinked""><a href=""/w/Special:RecentChangesLinked/cpp/atomic/atomic"" title=""Recent changes in pages linked from this page [k]"" accesskey=""k"">Related changes</a></li><li id=""t-upload""><a href=""http://upload.cppreference.com/w/Special:Upload"" title=""Upload files [u]"" accesskey=""u"">Upload file</a></li><li id=""t-specialpages""><a href=""/w/Special:SpecialPages"" title=""A list of all special pages [q]"" accesskey=""q"">Special pages</a></li><li id=""t-print""><a href=""/mwiki/index.php?title=cpp/atomic/atomic&amp;printable=yes"" rel=""alternate"" title=""Printable version of this page [p]"" accesskey=""p"">Printable version</a></li><li id=""t-permalink""><a href=""/mwiki/index.php?title=cpp/atomic/atomic&amp;oldid=124339"" title=""Permanent link to this revision of the page"">Permanent link</a></li><li id=""t-info""><a href=""/mwiki/index.php?title=cpp/atomic/atomic&amp;action=info"">Page information</a></li>            </ul>
        </div>
                        <div id=""cpp-languages"">
            <div><ul><li>In other languages</li></ul></div>
            <div><ul>
<li class=""interwiki-de""><a href=""http://de.cppreference.com/w/cpp/atomic/atomic"" title=""cpp/atomic/atomic"" lang=""de"" hreflang=""de"">Deutsch</a></li><li class=""interwiki-es""><a href=""http://es.cppreference.com/w/cpp/atomic/atomic"" title=""cpp/atomic/atomic"" lang=""es"" hreflang=""es"">Español</a></li><li class=""interwiki-fr""><a href=""http://fr.cppreference.com/w/cpp/atomic/atomic"" title=""cpp/atomic/atomic"" lang=""fr"" hreflang=""fr"">Français</a></li><li class=""interwiki-it""><a href=""http://it.cppreference.com/w/cpp/atomic/atomic"" title=""cpp/atomic/atomic"" lang=""it"" hreflang=""it"">Italiano</a></li><li class=""interwiki-ja""><a href=""http://ja.cppreference.com/w/cpp/atomic/atomic"" title=""cpp/atomic/atomic"" lang=""ja"" hreflang=""ja"">日本語</a></li><li class=""interwiki-pt""><a href=""http://pt.cppreference.com/w/cpp/atomic/atomic"" title=""cpp/atomic/atomic"" lang=""pt"" hreflang=""pt"">Português</a></li><li class=""interwiki-ru""><a href=""http://ru.cppreference.com/w/cpp/atomic/atomic"" title=""cpp/atomic/atomic"" lang=""ru"" hreflang=""ru"">Русский</a></li><li class=""interwiki-zh""><a href=""http://zh.cppreference.com/w/cpp/atomic/atomic"" title=""cpp/atomic/atomic"" lang=""zh"" hreflang=""zh"">中文</a></li>            </ul></div>
        </div>
            <ul id=""footer-info"">
                                    <li id=""footer-info-lastmod""> This page was last modified on 22 November 2020, at 06:54.</li>
                                    <li id=""footer-info-viewcount"">This page has been accessed 1,631,633 times.</li>
                            </ul>
                    <ul id=""footer-places"">
                                    <li id=""footer-places-privacy""><a href=""/w/Cppreference:Privacy_policy"" title=""Cppreference:Privacy policy"">Privacy policy</a></li>
                                    <li id=""footer-places-about""><a href=""/w/Cppreference:About"" title=""Cppreference:About"">About cppreference.com</a></li>
                                    <li id=""footer-places-disclaimer""><a href=""/w/Cppreference:General_disclaimer"" title=""Cppreference:General disclaimer"">Disclaimers</a></li>
                            </ul>
                                    <ul id=""footer-icons"" class=""noprint"">
                                    <li id=""footer-poweredbyico"">
                                            <a href=""//www.mediawiki.org/""><img src=""/mwiki/skins/common/images/poweredby_mediawiki_88x31.png"" alt=""Powered by MediaWiki"" width=""88"" height=""31"" /></a>                                            <a href=""http://qbnz.com/highlighter/""><img src=""//upload.cppreference.com/mwiki/images/2/2b/powered_by_geshi_88x31.png"" alt=""Powered by GeSHi"" height=""31"" width=""88"" /></a>                                            <a href=""http://www.tigertech.net/referral/cppreference.com""><img src=""//upload.cppreference.com/mwiki/images/9/94/powered_by_tigertech_88x31.png"" alt=""Hosted by Tiger Technologies"" height=""31"" width=""88"" /></a>                                        </li>
                                </ul>
                        <div style=""clear:both"">
            </div>
            </div>
        </div>
        <!-- /footer -->
        <script>if(window.mw){
mw.loader.state({""site"":""loading"",""user"":""missing"",""user.groups"":""ready""});
}</script>
<script src=""https://en.cppreference.com/mwiki/load.php?debug=false&amp;lang=en&amp;modules=skins.cppreference2&amp;only=scripts&amp;skin=cppreference2&amp;*""></script>
<script>if(window.mw){
mw.loader.load([""mediawiki.action.view.postEdit"",""mediawiki.user"",""mediawiki.page.ready"",""mediawiki.searchSuggest"",""mediawiki.hidpi"",""ext.gadget.ColiruCompiler"",""ext.gadget.MathJax""], null, true);
}</script>
<script src=""https://en.cppreference.com/mwiki/load.php?debug=false&amp;lang=en&amp;modules=site&amp;only=scripts&amp;skin=cppreference2&amp;*""></script>
<script type=""text/javascript"">
var gaJsHost = ((""https:"" == document.location.protocol) ? ""https://ssl."" : ""http://www."");
document.write(unescape(""%3Cscript src='"" + gaJsHost + ""google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E""));
</script>
<script type=""text/javascript"">
var _gaq = _gaq || [];
_gaq.push(['_setAccount', 'UA-2828341-1']);
_gaq.push(['_setDomainName', 'cppreference.com']);
_gaq.push(['_trackPageview']);
</script><!-- Served in 0.061 secs. -->
	</body>
<!-- Cached 20201209225052 -->
</html>
";

        public string Url { get; set; }

        private volatile bool DownloadCancled = false;

        public event EventHandler<DownloadProgressChangedEventArgs> DownloadProgressChanged;

        protected virtual void OnDownloadProgressChanged(DownloadProgressChangedEventArgs args)
        {
            DownloadProgressChanged?.Invoke(this, args);
        }
        protected virtual void OnDownloadProgressChanged(int progress)
        {
            OnDownloadProgressChanged(new DownloadProgressChangedEventArgs { Progress = progress });
        }

        public void CancelDownload()
        {
            DownloadCancled = true;
        }

        public string DownloadPage()
        {
            DownloadCancled = false;
            string downloaded_page = "";

            var page_part = PageContent.Length / 100;
            var duration_part = DownloadDuration / 100;
            for (var i = 0; i < 100; i++)
            {
                downloaded_page += PageContent.Substring(page_part * i, page_part);
                Thread.Sleep(duration_part);
                OnDownloadProgressChanged(i);

                if (DownloadCancled)
                {
                    break;
                }
            }

            return downloaded_page;
        }
    }
}
