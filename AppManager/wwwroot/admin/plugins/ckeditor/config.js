/**
 * @license Copyright (c) 2003-2022, CKSource Holding sp. z o.o. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
	config.syntaxhighlight_lang = 'csharp';
	config.syntaxhighlight_hideControls = 'true';
	config.language = 'vi';
	config.filebrowserBrowseUrl = '/admin/plugins/ckfinder/ckfinder.html';
	config.filebrowserImageBrowseUrl = '/admin/plugins/ckfinder/ckfinder.html?type=Images';
	config.filebrowserFlashBrowseUrl = '/admin/plugins/ckfinder/ckfinder.html?type=Flash';
	config.filebrowserUploadUrl = '/admin/plugins/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Files';
	config.filebrowserImageUploadUrl = '/Data';
	config.filebrowserFlashUploadUrl = '/admin/plugins/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Flash';
	CKFinder.setupCKEditor(null, '/admin/plugins/ckfinder');
};
