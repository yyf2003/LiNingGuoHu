/*
 * FCKeditor - The text editor for Internet - http://www.fckeditor.net
 * Copyright (C) 2003-2007 Frederico Caldeira Knabben
 *
 * == BEGIN LICENSE ==
 *
 * Licensed under the terms of any of the following licenses at your
 * choice:
 *
 *  - GNU General Public License Version 2 or later (the "GPL")
 *    http://www.gnu.org/licenses/gpl.html
 *
 *  - GNU Lesser General Public License Version 2.1 or later (the "LGPL")
 *    http://www.gnu.org/licenses/lgpl.html
 *
 *  - Mozilla Public License Version 1.1 or later (the "MPL")
 *    http://www.mozilla.org/MPL/MPL-1.1.html
 *
 * == END LICENSE ==
 *
 * This plugin register Toolbar items for the combos modifying the style to
 * not show the box.
 */

FCKCommands.RegisterCommand( 'InsertImage'		, new FCKDialogCommand( FCKLang.InsertImage, FCKLang.InsertImage, FCKConfig.BasePath + 'dialog/' + 'InsertImage.aspx'	, 340, 200 ) ) ;


FCKToolbarItems.RegisterItem( 'InsertImage'	, new FCKToolbarButton( 'InsertImage', FCKLang.InsertImageLbl, FCKLang.InsertImage, FCK_TOOLBARITEM_ICONTEXT, true, false, 37 ) ) ;
