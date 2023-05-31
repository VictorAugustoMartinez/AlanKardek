﻿CREATE TRIGGER TRG_TB_USUARIO ON [dbo].[tb_usuario] FOR INSERT, UPDATE, DELETE
AS
BEGIN
	DECLARE @NM_USUARIO  VARCHAR(100),
	        @TX_EMAIL    VARCHAR(100),
			@TX_SENHA    VARCHAR(10),
			@TP_USUARIO  VARCHAR(1),
			@IN_PRIVILEGIADO VARCHAR(1);
	--
	SELECT 
	@NM_USUARIO = NM_USUARIO,
	@TX_EMAIL = LOWER(TX_EMAIL),
	@TX_SENHA = TX_SENHA,
	@TP_USUARIO = TP_USUARIO,
	@IN_PRIVILEGIADO = IN_PRIVILEGIADO
	FROM INSERTED;
	--
	IF (@TP_USUARIO = 'A') SELECT @IN_PRIVILEGIADO = 'N';
	--
	INSERT INTO tb_usuario (NM_USUARIO, TX_EMAIL, TX_SENHA, TP_USUARIO, IN_PRIVILEGIADO)
	VALUES (@NM_USUARIO, @TX_EMAIL, @TX_SENHA, @TP_USUARIO, @IN_PRIVILEGIADO);
	--
	COMMIT;
END;