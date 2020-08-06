// /api/admin/info
import axios from 'axios';
import store from '../store';
const st = store.state;
const token = st.auth.user.access_token;
axios.defaults.headers.common = { Authorization: `bearer ${token}` };
const API_URL = 'https://localhost:44385/api/admin/';
class AdminService {
    getAdminInfo() {
        return axios.get(API_URL + 'info');
    }
}
export default new AdminService();
//# sourceMappingURL=admin.service.js.map