<?php

namespace gui;
class Layout
{
    protected $templateFile;

    public function __construct( $templateFile )
    {
        $this->templateFile = $templateFile;
    }

    public function display( $title,$nav , $content )
    {
        $page = file_get_contents( $this->templateFile );
        $page = str_replace( ['%title%','%nav%','%content%'], [$title,$nav,$content], $page);
        echo $page;
    }

}