import axios from "axios"

const authenticationService = async (token: string) => {
    
    try {
        await axios.get("http://localhost:5000/user",
        {
            headers: {
                Authorization : `Bearer ${token}`
            }
        });

        console.log("success")
        return true;
    } catch (err) {
        console.log("unauthorized")
        return false;
    }
}

export default authenticationService;