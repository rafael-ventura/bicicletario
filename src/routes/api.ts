import express from 'express';
import UserRoutes from './UsuarioRoutes';
import Paths from '@src/constants/Paths';

// Inicializa o Router do Express.
const router = express.Router();

// Mapeia as rotas do usuário
router.use(Paths.Users.Get, UserRoutes.getAll);
router.use(Paths.Users.Add, UserRoutes.add);
router.use(Paths.Users.Update, UserRoutes.update);
router.use(Paths.Users.Delete, UserRoutes.delete);

export default router;
