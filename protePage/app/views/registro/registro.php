<?php

use \helpers\form as Form,
    \core\language as Language,
    \core\error as Error;

$planteles = "<option value='0'>" . Language::show('selec', 'registro') . "</option>";
if ($data['plantelesRows']) {
    foreach ($data['plantelesRows'] as $row) {
        $planteles .= "<option value='" . $row->idplantel . "'>" . $row->nombre . "</option>";
    }
}
$foranea = "<option value='0'>" . Language::show('selec', 'registro') . "</option>";
if ($data['foraneaRows']) {
    foreach ($data['foraneaRows'] as $row) {
        $foranea .= "<option value='" . $row->idescuelaForanea . "'>" . $row->nombre . "</option>";
    }
}
?>
<h1><?php echo Language::show('registro', 'registro'); ?></h1>
<hr />
<div class='row'>
    <div class='col-md-offset-1 col-md-10'>
        <div class="alert alert-warning">
            <p><?php echo Language::show('necesitas', 'registro') ?><a href="<?php echo DIR ?>login" class="hover-menu"><strong class="alert-link"> <?php echo Language::show('sesion', 'registro') ?></strong></a></p>
        </div>
        <div class="well">
            <?php echo Form::open(array('method' => 'post', 'id' => 'formu', 'class' => 'form-horizontal', 'accept-charset' => 'utf-8')); ?>
            <div class="form-group">
                <label for="nombre" class="col-sm-2 control-label"><?php echo Language::show('nombre', 'registro') ?></label>
                <div class="col-sm-10">
                    <input type="text" maxlength="40" class="form-control" name="nombre" placeholder="<?php echo Language::show('nombre', 'registro') ?>" required>
                </div>
            </div>
            <div class="form-group">
                <label for="apaterno" class="col-sm-2 control-label"><?php echo Language::show('apaterno', 'registro') ?></label>
                <div class="col-sm-10">
                    <input type="text" maxlength="40" class="form-control" name="apaterno" placeholder="<?php echo Language::show('apaterno', 'registro') ?>" required>
                </div>
            </div>
            <div class="form-group">
                <label for="amaterno" class="col-sm-2 control-label"><?php echo Language::show('amaterno', 'registro') ?></label>
                <div class="col-sm-10">
                    <input type="text" maxlength="40" class="form-control" name="amaterno" placeholder="<?php echo Language::show('amaterno', 'registro') ?>" required>
                </div>
            </div>
            <div class="form-group">
                <label for="email" class="col-sm-2 control-label"><?php echo Language::show('correo', 'registro') ?></label>
                <div class="col-sm-10">
                    <input type="email" maxlength="40" class="form-control" name="email" placeholder="<?php echo Language::show('correo', 'registro') ?>" required>
                </div>
            </div>
            <div class="form-group">
                <label for="password" class="col-sm-2 control-label"><?php echo Language::show('password', 'registro') ?></label>
                <div class="col-sm-10">
                    <input type="password" maxlength="30" class="form-control" id='pass' name="password" placeholder="<?php echo Language::show('password', 'registro') ?>" required>
                </div>
            </div>
            <div class="form-group">
                <label for="password2" class="col-sm-2 control-label"><?php echo Language::show('confirmar', 'registro') ?></label>
                <div class="col-sm-10">
                    <input type="password" maxlength="30" class="form-control" id='passC' name="password2" placeholder="<?php echo Language::show('confirmar', 'registro') ?>" required>
                </div>
            </div>
            <div class="form-group">
                <label for="captcha" class="col-sm-2 control-label" id="captchaOperation"></label>
                <div class="col-sm-10">
                    <input type="text" class="form-control" name="captcha" placeholder="<?php echo Language::show('captcha', 'registro') ?>"/>
                </div>
            </div>
            <div class="form-group">
                <label for="tipoUsuario" class="col-sm-2 control-label"><?php echo Language::show('proc', 'registro') ?></label>
                <div class="col-sm-10">
                    <select class="form-control" name="tipoUsuario" id="tipoUsuario">
                        <option value="0"><?php echo Language::show('selec', 'registro') ?></option>
                        <option value="1"><?php echo Language::show('unam', 'registro') ?></option>
                        <option value="2"><?php echo Language::show('externo', 'registro') ?></option>
                        <option value="3"><?php echo Language::show('publico', 'registro') ?></option>
                    </select>
                </div>
            </div>
            <div id='tipoDIV'>
                <div id="UNAM">
                    <div class="form-group">
                        <label for="cuenta" class="col-sm-2 control-label"><?php echo Language::show('cuenta', 'registro') ?></label>
                        <div class="col-sm-10">
                            <input type="text" maxlength="9" class="form-control" name="cuenta" placeholder="<?php echo Language::show('cuenta', 'registro') ?>" required>
                            <p class="text-warning"><?php echo Language::show('avisoR', 'registro') ?></p>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="plantel" class="col-sm-2 control-label"><?php echo Language::show('plantel', 'registro') ?></label>
                        <div class="col-sm-10">
                            <select class="form-control" name="plantel" id="plantel">
                                <?php echo $planteles ?>
                            </select>
                        </div>
                    </div>
                    <div id="unamDos">
                        <div class="form-group" id="carreraDiv">
                            <label for="carrera" class="col-sm-2 control-label"><?php echo Language::show('carrera', 'registro') ?></label>
                            <div class="col-sm-10">
                                <select class="form-control" id="carrera" name="carrera"></select>
                            </div>
                        </div>
                        <div class="form-group text-center">
                            <input type="hidden" name="registroUNAM" value="1">
                            <?php echo Form::input(array('id' => 'botonUNAM', 'class' => 'btn btn-warning', 'type' => 'submit', 'value' => Language::show('registrarme', 'registro'))); ?>
                        </div>
                    </div>
                </div>
                <div id="externo">
                    <div class="form-group">
                        <label for="rfc1" class="col-sm-2 control-label"><?php echo Language::show('rfc', 'registro') ?></label>
                        <div class="col-sm-10">
                            <input type="text" maxlength="13" class="form-control" name="rfc1" placeholder="<?php echo Language::show('rfc', 'registro') ?>" required>
                            <a href="https://www.recaudanet.gob.mx/recaudanet/rfc.jsp" target="_blank"><?php echo Language::show('no_sabes', 'registro') ?></a>
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="foranea" class="col-sm-2 control-label"><?php echo Language::show('escuela', 'registro') ?></label>
                        <div class="col-sm-10">
                            <select class="form-control" name="foranea" id="foranea">
                                <?php echo $foranea ?>
                            </select>
                        </div>
                    </div>
                    <div class="form-group text-center">
                        <input type="hidden" name="registroForaneo" value="2">
                        <?php echo Form::input(array('id' => 'botonExterno', 'class' => 'btn btn-warning', 'type' => 'submit', 'value' => Language::show('registrarme', 'registro'))); ?>
                    </div>
                </div>
                <div id="general">
                    <div class="form-group">
                        <label for="rfc2" class="col-sm-2 control-label"><?php echo Language::show('rfc', 'registro') ?></label>
                        <div class="col-sm-10">
                            <input type="text" maxlength="13" class="form-control" name="rfc2" placeholder="<?php echo Language::show('rfc', 'registro') ?>" required>
                            <a href="https://www.recaudanet.gob.mx/recaudanet/rfc.jsp" target="_blank"><?php echo Language::show('no_sabes', 'registro') ?></a>
                        </div>
                    </div>
                    <div class="form-group text-center">
                        <input type="hidden" name="registroGeneral" value="3">
                        <?php echo Form::input(array('id' => 'botonGeneral', 'class' => 'btn btn-warning', 'type' => 'submit', 'value' => Language::show('registrarme', 'registro'))); ?>
                    </div>
                </div>
            </div>
            <?php echo Form::close(); ?>
        </div>
        <?php echo Error::display($error); ?>
        <div class="alert alert-warning">
            <p><?php echo Language::show('correcto', 'registro') ?></p>
        </div>
    </div>
</div>