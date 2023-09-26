/**
 * @swagger
 * components:
 *   schemas:
 *     LoginRequest:
 *       type: object
 *       required:
 *         - email
 *         - senha
 *       properties:
 *         email:
 *           type: string
 *           format: email
 *         senha:
 *           type: string
 *           format: password
 *     RecuperacaoSenhaRequest:
 *       type: object
 *       required:
 *         - email
 *       properties:
 *         email:
 *           type: string
 *           format: email
 */
