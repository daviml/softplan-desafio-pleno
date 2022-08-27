import api from "../api";

export const buscaSalasService = async () => await api.get('busca-salas');

export const insereReservaService = async (data) => await api.post('insere-reserva', data);
