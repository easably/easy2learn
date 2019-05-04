using System;
using System.Collections.Generic;
using System.Text;

namespace f
{
    public class Lingvo : DictionaryProvider
    {
        public override string Title { get { return "Lingvo"; } }
        public override string Copyright { get { return "© 1996-2010  ABBYY"; } }
        // http://lingvo.abbyyonline.com/en/en-ru/merely
        public override string URL { get
        {
            return @"http://lingvopro.abbyyonline.com/en/Search/{1}-{2}/{0}";
        } }


        public override string[] StartTags { get { return new string[] { "<div class=\"js-section-data" }; } }
        // это див с заголовком
        //public override string[] StartTags { get { return new string[] { "<div class=\"l-articles js-section-box" }; } }
     
        
        //   public override string[] StartTags { get { return new string[] {"<div class=\"b-search-results\""}; } }
       //public override string[] StartTags { get { return new string[] {"<div class=\"rdiv wh-gr\" id=\"trans\""}; } }
        
        public override string CorrectionURL
        {
            get
            {
                return @"http://lingvopro.abbyyonline.com/";
            }
        }
        public override string[] Languages { get { return new string[] {                                                              
            //"en:en", 
            "en:de", "en:fr", "en:sp", "en:ru", "en:uk", "en:it", // mono
            "fr:de", "fr:en", "fr:de", 
            //"de:de", 
            "de:en", "de:fr", "de:it", "de:ru", "de:sp", // mono
            "it:ru", "it:en", "it:de",
            "la:ru", 
            //"ru:ru", 
            "ru:en", "ru:fr", "ru:de", "ru:it", "ru:la", "ru:sp", "ru:uk", // mono
            "sp:en", "sp:de", "sp:ru",
            "uk:en", "uk:uk", "uk:ru", // mono
                                                              };
            }
        }

        public override string Styles
        {
            get
            {
                return @"<link href=""http://lingvopro.abbyyonline.com/ContentAOL/abbyyonline.css"" type=""text/css"" rel=""Stylesheet"">"
                    +
                    @"<link href=""http://www.lingvo-online.ru/Content/2.0.29865.1632/CssStandard"" rel=""stylesheet"" type=""text/css"">";
        
            }
        }
        //        return @"<link href=""http://lingvopro.abbyyonline.com/Content/1.8.18255.523/CssIE"" rel=""stylesheet"" type=""text/css"" /><link href=""http://lingvopro.abbyyonline.com/Content/1.8.18255.523/CssIE678"" rel=""stylesheet"" type=""text/css"" />";
        //  .b-add-translation .tabs{display:inline;zoom:1;}.b-add-translation .tabs .all-c{font-size:2px;}.b-add-translation .text-trans .virtual-keyboard-cell{//padding-top:2px;}.b-add-translation__specialDropDown{_zoom:1;}.b-add-translation__specialDropDown__sel{//filter:alpha(opacity=0);//margin-top:3px;} .b-bonuses .dash{//margin:0 0 4px;//display:inline-block;}.b-bonuses .part-serial-number{//display:inline;//zoom:1;}.b-bonuses-form{//display:inline;//zoom:1;}.b-roundbox_bonus-hover .b-roundbox_bonus__lt,.b-roundbox_bonus-hover .b-roundbox_bonus__rt,.b-roundbox_bonus-hover .b-roundbox_bonus__rb,.b-roundbox_bonus-hover .b-roundbox_bonus__lb{_font-size:2px;}.b-roundbox_bonus__icon{_font-size:2px;}.b-roundbox_bonus{_zoom:1;}.b-bonuses-form .all-line .r-t-c{_right:0;}.b-bonuses-form .all-line .r-b-c{_right:0;}.b-bonuses-form .all-line .all-corn{_font-size:2px;}.b-bonuses-form .all-line .all-corn{_font-size:2px;} .b-bookmarks{//display:inline;//zoom:1;}.b-bookmarks_sky{_margin-right:-3px;} .b-bubbling-help .top{//font-size:2px;}.b-bubbling-help .bott{//font-size:2px;} .b-button{//display:inline;//zoom:1;}.b-button .button{overflow:visible;}.b-button_main{position:absolute;}.b-button_blue .button{padding:4px 15px;}.b-button_blue_hideStatistic .button{padding-top:5px;padding-bottom:5px;} .b-context-help .all-c{font-size:2px;} .b-dictionaries__search{_zoom:1;}.b-dictionaries__search__style{_height:83px;}.b-dictionaries__search__style_lt,.b-dictionaries__search__style_rt,.b-dictionaries__search__style_rb,.b-dictionaries__search__style_lb{_font-size:2px;} .b-dictionaries_one .about-dictionary{zoom:1;}.b-dictionaries_one .manual-info .all-c{font-size:6px;}.b-dictionaries_one .book-mark{display:inline;zoom:1;} .b-enterprise-tabs__li,.b-enterprise-actions__li{//display:inline;//zoom:1;}.b-enterprise-actions__li__link{//display:inline;//zoom:1;}.b-ordered-asc .b-enterprise-account__sorting_asc,.b-ordered-desc .b-enterprise-account__sorting_desc{//top:-3px;}.b-enterprise-account__popupEditSugg__table{//position:relative;}.b-enterprise-account__popupEditGloss__table__trigger{//top:-5px;}.b-enterprise-account__popupAddUsers__table{width:100%:;}.b-enterprise-actions__users__tdname__wordwrap,.b-enterprise-actions__users__tdemail__wordwrap,.b-enterprise-actions__gloss__tdautor__wordwrap,.b-enterprise-actions__gloss__tdname__wordwrap,.b-enterprise-actions__gloss__tdsource__wordwrap,.b-enterprise-actions__gloss__tdtarget__wordwrap{//overflow:hidden;}.b-enterprise-account__popupAddUsers__tdAccessLevel,.b-enterprise-account__popupAddUsers__tdEmail,.b-enterprise-account__popupAddUsers__tdLangMess{//width:126px;}.b-enterprise-account__popupAddUsers__tdDropDown,.b-enterprise-account__popupAddUsers__tdInputText{//width:170px;} .b-examples-table .example-text .sup-elem{//vertical-align:baseline;_margin-top:-2px;}.b-examples-table-controls a{text-decoration:none;} .b-ie67-fixLineHeight{display:inline-block;} .b-home-links_search,.b-home-links_еxamples,.b-home-links_translate,.b-home-links_contact{//display:inline;//zoom:1;}.b-home-links_search__item,.b-home-links_еxamples__item,.b-home-links_translate__item,.b-home-links_contact__item{_height:auto!important;_height:171px;}.b-home-links_search__icon,.b-home-links_еxamples__icon,.b-home-links_translate__icon,.b-home-links_contact__icon{//z-index:-1;}.b-home-links_search__header_text,.b-home-links_еxamples__header_text,.b-home-links_translate__header_text,.b-home-links_contact__header_text{//cursor:pointer;} .card .Superscript{zoom:1;}.card .Subscript{zoom:1;} .b-main-page .news{zoom:1;} .b-pagination .inner{//display:inline;//zoom:1;}.b-pagination .all-b{//display:inline;//zoom:1;}.b-pagination .all-b .r-t{_right:-1px;}.b-pagination .all-b .direction-links{//display:inline-block;//width:25px;//height:22px;}.b-pagination .all-b .direction-links img{//float:left;} .b-bg-popup{//filter:alpha(opacity=0);}.b-popup_confirm .all-line .all-corn{_font-size:2px;} .b-glossary__gallery__iefix{width:0;display:inline-block;overflow:hidden;} .b-slidesidebar{_background:#efefef;_zoom:1;}.b-slidesidebar-srcdata,.b-slidesidebar-destdata{_zoom:1;}.b-slidesidebar__glossaryData{_zoom:1;}.b-slidesidebar__glossarySelect{//filter:alpha(opacity=0);//margin-top:3px;} .b-search-panel_short .b-roundbox__search{position:static;}.b-search-panel_short .b-roundbox__search__rb{bottom:25px;} .b-search-panel input.text{zoom:0!important;}.b-search-panel td.lang .additional{display:inline;zoom:1;}.b-search-results__pageNav__link__icon{//vertical-align:baseline;} .b-search-results .bookmark-abbyy{//z-index:-1;}.b-search-results .lingvo .data{//height:auto!important;//height:35px;} .b-subjects-menu{zoom:1;//z-index:10;}.b-subjects-menu .all-item-li{display:inline;zoom:1;}.b-subjects-menu .item-link_opened{border-bottom:1px solid #edf7fa;}.b-subjects-menu .item-link .arrow-mini{*top:0;_top:4px;}.drop-downList{_width:116px;left:0;margin-top:24px;}.drop-downList .all{_widht:auto;*width:100px;}.drop-downList .all-corn{font-size:2px;}.drop-downList .all-item-li-down{_zoom:1;width:auto!important;width:114px;}.drop-downList .all-item-li-down a{zoom:1;} .b-links-box .list-item{//display:inline;//zoom:1;} .b-window-examples .all-corn{font-size:2px;}.help-item .all-b{font-size:2px;}.b-window-examples .inside-content{height:auto!important;height:20px;}.b-window-examples .header{zoom:1;}.b-window-examples .chief-text{zoom:1;}.b-window-examples .arrow-example{left:2px;}..b-window-examples__tabs__tab{//display:inline;//zoom:1;}* html*.g-png{zoom:expression(runtimeStyle.zoom = 1,runtimeStyle.filter+= "progid:DXImageTransform.Microsoft.AlphaImageLoader(src="+getElementsByTagName("img")[0].src+")");}* html*.g-png img{visibility:expression(runtimeStyle.visibility="hidden",parentNode.insertBefore(createElement("png"),this));}* html*.g-png png{font-size:0;position:absolute;width:expression(runtimeStyle.width = parentNode.offsetWidth+"px");height:expression(runtimeStyle.height = parentNode.offsetHeight+"px");}* html a.g-png,* html a .g-png,* html .g-png a{cursor:hand;} br.clear{_font-size:0;}.page{_height:100%;}.b-head_ua__lb,.b-head_ua__rb,.b-head_ua__border{_font-size:2px;}.nojs .b-warningBox__global{display:none;}
        // .b-buttons{//display:inline;//zoom:1;}.b-buttons__button{filter:alpha(opacity=0);//overflow:visible;}.b-buttons_general__text,.b-buttons_general__button{//font-size:1.15em;} .b-globalPopup__corn{border:none;background:none;}.b-globalPopup__corn__bg{position:absolute;top:5px;left:3px;right:3px;bottom:5px;background:#fff;}.b-globalPopup__corn__lt,.b-globalPopup__corn__rt,.b-globalPopup__corn__rb,.b-globalPopup__corn__lb{position:absolute;width:51%;height:13px;background:url("img/global-popup-bg.png") no-repeat scroll 0 0;}.b-globalPopup__corn__lt{left:0;top:0;}.b-globalPopup__corn__rt{right:0;top:0;background-position:100% 0;}.b-globalPopup__corn__rb{right:0;bottom:0;background-position:100% -14px;}.b-globalPopup__corn__lb{left:0;bottom:0;background-position:0 -14px;}.b-globalPopup__corn__bordersLR{position:absolute;top:13px;bottom:13px;left:0;right:0;border-left:3px solid #2b99b7;border-right:3px solid #2b99b7;}.b-globalPopup__corn__lineTop,.b-globalPopup__corn__lineBottom{position:absolute;left:11px;right:11px;top:3px;bottom:3px;border-top:1px solid #fff;border-bottom:1px solid #fff;}.b-globalPopup__corn__lineBottom{left:9px;right:9px;top:4px;bottom:4px;}.b-globalPopup__corn__grayBg{left:3px;top:3px;right:3px;bottom:3px;width:auto;height:auto;background:none;border-bottom:37px solid #e8e8e8;} .b-window-examples__helpInfo__corn__lt,.b-window-examples__helpInfo__corn__rt,.b-window-examples__helpInfo__corn__rb,.b-window-examples__helpInfo__corn__lb{position:absolute;width:5px;height:5px;background:url("img/b-window-examples-help.png") no-repeat 0 0;}.b-window-examples__helpInfo__corn__lt{left:0;top:0;}.b-window-examples__helpInfo__corn__rt{right:0;top:0;background-position:0 -5px;}.b-window-examples__helpInfo__corn__rb{right:0;bottom:0;background-position:0 -10px;}.b-window-examples__helpInfo__corn__lb{left:0;bottom:0;background-position:0 -15px;} .b-search-panel{_background:#227899;}.b-search-panel__grad{//zoom:1;}.b-roundbox__menutabs_active__rb,.b-roundbox__menutabs_active__lb,.b-roundbox__menutabs__rb,.b-roundbox__menutabs__lb{position:absolute;bottom:0;width:11px;height:14px;background:url("img/header-bg.png") no-repeat 0 -50px;_display:none;}.b-roundbox__menutabs_active__rb{right:0;}.b-roundbox__menutabs_active__lb{background-position:0 -36px;left:0;}.b-roundbox__menutabs__lb{left:0;background-position:0 -64px;height:10px;}.b-roundbox__menutabs__rb{background-position:0 -74px;right:0;height:10px;}.b-roundbox__menutabs_active__b-line{border-top:3px solid #ebebeb;margin:0 11px;} .b-roundBox{//zoom:1;}.b-roundBox__corn{border:1px solid #d1d1d1;filter:progid:DXImageTransform.Microsoft.gradient(enabled='true',startColorstr=#ffffff,endColorstr=#EFEFEF,GradientType=0);}


    }
}
