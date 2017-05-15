<?php

namespace core;

/* model - the base model */

abstract class Model extends Controller {

    /**
     * hold the database connection
     * @var object
     */
    protected $_db;

    /**
     * create a new instance of the database helper
     */
    public function __construct() {

        //connect to PDO here.
        $this->_db = \helpers\database::get();
    }

}
