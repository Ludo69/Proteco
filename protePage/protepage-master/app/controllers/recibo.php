<?php

namespace controllers;

use \helpers\session as Session,
    \helpers\url as Url;

class Recibo extends \core\controller
{

    private $_pdf;
    private $_model;

    public function __construct()
    {
        parent::__construct();
        if (!Session::get('loggedin') && !Session::get('id')) {
            Url::redirect();
        }

        $this->_pdf = new \fpdi\FPDI();
        $this->_model = new \models\recibo();
    }

    public function generar()
    {
        $folio = $_SESSION['folio'];
        $id = $_SESSION['id'];
        $semestre = $this->_model->get_semestre();
        $usuarioRows = $this->_model->get_usuario($folio);
        $cursos = $this->_model->get_cursos($folio);
        $this->_pdf->AddPage();
        switch ($_SERVER['HTTP_HOST']) {
            case '127.0.0.1':
            case 'localhost':
                if (is_dir("/opt/lampp/htdocs/proteco/app/assets/")) {
                    $this->_pdf->setSourceFile("/opt/lampp/htdocs/proteco/app/assets/recibo.pdf");
                } else {
                    $this->_pdf->setSourceFile("/opt/lampp/htdocs/proteco/app/assets/recibo.pdf");
                    //RUTA ABSOLUTA HASTA AQUI
                }
                break;
            case 'proteco.mx':
                $this->_pdf->setSourceFile("/kunden/homepages/36/d576278833/htdocs/proteco/app/assets/recibo.pdf");
                break;
        }
        $this->_pdf->useTemplate($this->_pdf->importPage(1), 0, 0, null, null);
        $this->_pdf->SetFont('Arial');
        $this->_pdf->SetFontSize(12);
        $this->_pdf->SetTextColor(0, 0, 0);
        $this->_pdf->SetXY(90, 45);
        $this->_pdf->Write(0, $semestre);
        $this->_pdf->SetXY(33, 72);
        $this->_pdf->Write(0, $folio);
        $this->_pdf->SetXY(39, 78);
        $this->_pdf->Write(0, utf8_decode($usuarioRows[0]->nombres) . " " . utf8_decode($usuarioRows[0]->apellidoP) . " " . utf8_decode($usuarioRows[0]->apellidoM));
        $this->_pdf->SetXY(37, 83.5);
        $this->_pdf->Write(0, $usuarioRows[0]->correo);
        $this->_pdf->SetFontSize(14);
        $this->_pdf->SetXY(19, 88.5);
        if ($usuarioRows[0]->tipo == 1) {
            $cuenta = $this->_model->get_usuario_unam($id);
            $this->_pdf->Write(0, "Cuenta: ");
            $this->_pdf->SetFontSize(12);
            $this->_pdf->SetXY(37, 88.5);
            $this->_pdf->Write(0, $cuenta[0]->noCuenta);
        } elseif ($usuarioRows[0]->tipo == 2) {
            $cuenta = $this->_model->get_usuario_externo($id);
            $this->_pdf->Write(0, "RFC: ");
            $this->_pdf->SetFontSize(12);
            $this->_pdf->SetXY(32, 88.5);
            $this->_pdf->Write(0, $cuenta[0]->RFC);
        } elseif ($usuarioRows[0]->tipo == 3) {
            $cuenta = $this->_model->get_usuario_general($id);
            $this->_pdf->Write(0, "RFC: ");
            $this->_pdf->SetFontSize(12);
            $this->_pdf->SetXY(32, 88.5);
            $this->_pdf->Write(0, $cuenta[0]->RFC);
        }
        $this->_pdf->SetXY(19, 110);
        $i = 1;
        $space = 8;
        $horario = "";
        foreach ($cursos as $row) {
            if ($row->horario == 5) {
                $horario = "AM";
            } elseif ($row->horario == 6) {
                $horario = "PM";
            }
            $this->_pdf->Write(0, $i . " - " . utf8_decode($row->nombre) . " | " . date("d-m-Y", strtotime($row->fecha)) . " | " . $horario);
            $this->_pdf->SetXY(19, 110 + $space);
            $space += 8;
            $i++;
        }
        $this->_pdf->SetFontSize(14);
        $this->_pdf->SetFont('Arial', 'B');
        $this->_pdf->SetXY(19, 110 + $space);
        $this->_pdf->Write(0, "Total a pagar: $" . " " . $usuarioRows[0]->cuota);
        $this->_pdf->Output();
    }

    //Para generar un comprobante de pago con la mitad de precio
    //Solo para asistentes que hayan inscrito más de un curso
    public function generar2()
    {
        $folio = $_SESSION['folio'];
        $id = $_SESSION['id'];
        $cursos = $this->_model->get_cursos($folio);
        if(sizeof($cursos) > 1){

            $semestre = $this->_model->get_semestre();
            $usuarioRows = $this->_model->get_usuario($folio);
        
            $this->_pdf->AddPage();
            switch ($_SERVER['HTTP_HOST']) {
                case '127.0.0.1':
                case 'localhost':
                    if (is_dir("/opt/lampp/htdocs/proteco/app/assets/")) {
                        $this->_pdf->setSourceFile("/opt/lampp/htdocs/proteco/app/assets/recibo.pdf");
                    } else {
                        $this->_pdf->setSourceFile("/opt/lampp/htdocs/proteco/app/assets/recibo.pdf");
                        //RUTA ABSOLUTA HASTA AQUI
                    }
                    break;
                case 'proteco.mx':
                    $this->_pdf->setSourceFile("/kunden/homepages/36/d576278833/htdocs/proteco/app/assets/recibo.pdf");
                    break;
            }
            $this->_pdf->useTemplate($this->_pdf->importPage(1), 0, 0, null, null);
            $this->_pdf->SetFont('Arial');
            $this->_pdf->SetFontSize(12);
            $this->_pdf->SetTextColor(0, 0, 0);
            $this->_pdf->SetXY(90, 45);
            $this->_pdf->Write(0, $semestre);
            $this->_pdf->SetXY(33, 72);
            $this->_pdf->Write(0, $folio);
            $this->_pdf->SetXY(39, 78);
            $this->_pdf->Write(0, utf8_decode($usuarioRows[0]->nombres) . " " . utf8_decode($usuarioRows[0]->apellidoP) . " " . utf8_decode($usuarioRows[0]->apellidoM));
            $this->_pdf->SetXY(37, 83.5);
            $this->_pdf->Write(0, $usuarioRows[0]->correo);
            $this->_pdf->SetFontSize(14);
            $this->_pdf->SetXY(19, 88.5);
            if ($usuarioRows[0]->tipo == 1) {
                $cuenta = $this->_model->get_usuario_unam($id);
                $this->_pdf->Write(0, "Cuenta: ");
                $this->_pdf->SetFontSize(12);
                $this->_pdf->SetXY(37, 88.5);
                $this->_pdf->Write(0, $cuenta[0]->noCuenta);
            } elseif ($usuarioRows[0]->tipo == 2) {
                $cuenta = $this->_model->get_usuario_externo($id);
                $this->_pdf->Write(0, "RFC: ");
                $this->_pdf->SetFontSize(12);
                $this->_pdf->SetXY(32, 88.5);
                $this->_pdf->Write(0, $cuenta[0]->RFC);
            } elseif ($usuarioRows[0]->tipo == 3) {
                $cuenta = $this->_model->get_usuario_general($id);
                $this->_pdf->Write(0, "RFC: ");
                $this->_pdf->SetFontSize(12);
                $this->_pdf->SetXY(32, 88.5);
                $this->_pdf->Write(0, $cuenta[0]->RFC);
            }
            $this->_pdf->SetXY(19, 110);
            $i = 1;
            $space = 8;
            $horario = "";
            foreach ($cursos as $row) {
                if ($row->horario == 5) {
                    $horario = "AM";
                } elseif ($row->horario == 6) {
                    $horario = "PM";
                }
                $this->_pdf->Write(0, $i . " - " . utf8_decode($row->nombre) . " | " . date("d-m-Y", strtotime($row->fecha)) . " | " . $horario);
                $this->_pdf->SetXY(19, 110 + $space);
                $space += 8;
                $i++;
            }
            $this->_pdf->SetFontSize(14);
            $this->_pdf->SetFont('Arial', 'B');
            $this->_pdf->SetXY(19, 110 + $space);
            $this->_pdf->Write(0, "Pago Parcial de: $" . " " . ($usuarioRows[0]->cuota)/2);
            $this->_pdf->SetFontSize(10);
            $this->_pdf->SetFont('Arial', 'B');
            $this->_pdf->SetXY(19, 110 + $space + 6);
            $this->_pdf->Write(0, "El pago total debe ser liquidado");
            $this->_pdf->SetXY(19, 110 + $space + 10);
            $this->_pdf->Write(0, "antes del inicio de los cursos inscritos.");
            $this->_pdf->Output();
        }
        else{
            Url::redirect('miscursos');
        }
    }

    public function arduino()
    {
        $email = $_SESSION['email'];
        $id = $_SESSION['id'];
        $usuarioRows = $this->_model->get_user($email, $id);
        $arduino = $this->_model->getMaterial(1);
        $this->_pdf->AddPage();
        switch ($_SERVER['HTTP_HOST']) {
            case '127.0.0.1':
            case 'localhost':
                if (is_dir("/opt/lampp/htdocs/proteco/app/assets/")) {
                    $this->_pdf->setSourceFile("/opt/lampp/htdocs/proteco/app/assets/recibo2.pdf");
                } else {
                    $this->_pdf->setSourceFile("/opt/lampp/htdocs/proteco/app/assets/recibo2.pdf");
                    //comentario de rutasssss
                }
                break;
            case 'proteco.mx':
                $this->_pdf->setSourceFile("/kunden/homepages/36/d576278833/htdocs/proteco/app/assets/recibo2.pdf");
                break;
        }
        $this->_pdf->useTemplate($this->_pdf->importPage(1), 0, 0, null, null);
        $this->_pdf->SetFont('Arial');
        $this->_pdf->SetFontSize(12);
        $this->_pdf->SetTextColor(0, 0, 0);
        $this->_pdf->SetXY(39, 72.5);
        $this->_pdf->Write(0, utf8_decode($usuarioRows[0]->nombres) . " " . utf8_decode($usuarioRows[0]->apellidoP) . " " . utf8_decode($usuarioRows[0]->apellidoM));
        $this->_pdf->SetXY(37, 78);
        $this->_pdf->Write(0, $usuarioRows[0]->correo);
        $this->_pdf->SetFontSize(14);
        $this->_pdf->SetXY(19, 83.5);
        if ($usuarioRows[0]->tipo == 1) {
            $cuenta = $this->_model->get_usuario_unam($id);
            $this->_pdf->Write(0, "Cuenta: ");
            $this->_pdf->SetFontSize(12);
            $this->_pdf->SetXY(37, 83.5);
            $this->_pdf->Write(0, $cuenta[0]->noCuenta);
        } elseif ($usuarioRows[0]->tipo == 2) {
            $cuenta = $this->_model->get_usuario_externo($id);
            $this->_pdf->Write(0, "RFC: ");
            $this->_pdf->SetFontSize(12);
            $this->_pdf->SetXY(32, 83.5);
            $this->_pdf->Write(0, $cuenta[0]->RFC);
        } elseif ($usuarioRows[0]->tipo == 3) {
            $cuenta = $this->_model->get_usuario_general($id);
            $this->_pdf->Write(0, "RFC: ");
            $this->_pdf->SetFontSize(12);
            $this->_pdf->SetXY(32, 83.5);
            $this->_pdf->Write(0, $cuenta[0]->RFC);
        }
        $this->_pdf->SetXY(19, 118);
        $this->_pdf->Write(0, $arduino[0]->nombre);
        $this->_pdf->SetFontSize(14);
        $this->_pdf->SetFont('Arial', 'B');
        $this->_pdf->SetXY(19, 132);
        $this->_pdf->Write(0, "Total a pagar: $" . " " . $arduino[0]->precio);
        $this->_pdf->Output();
    }

}
