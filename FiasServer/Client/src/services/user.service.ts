import axios from 'axios'

const API_URL = 'https://localhost:44385/api/test/'

class UserService {
  getPublicContent () {
    return axios.get(API_URL + 'all')
  }

  getUserBoard () {
    return axios.get(API_URL + 'user')
  }

  getModeratorBoard () {
    return axios.get(API_URL + 'mod')
  }

  getAdminBoard () {
    return axios.get(API_URL + 'admin')
  }
}

export default new UserService()
