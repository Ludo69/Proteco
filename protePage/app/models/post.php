<?php

namespace models;

class Post extends \core\model {

    public function getposts() {
        return $this->_db->select("SELECT * FROM noticia ORDER BY fechaHora DESC");
    }

    public function getpost($id) {
        return $this->_db->select("SELECT * FROM noticia WHERE idnoticia = :id",array(':id' => $id));
    }

    public function insert_post($data) {
        $this->_db->insert('noticia', $data);
    }

    public function update_post($data, $where) {
    	$this->_db->update('noticia', $data, $where);
    }

    public function delete_post($where) {
        $this->_db->delete('noticia', $where);
    }

}
