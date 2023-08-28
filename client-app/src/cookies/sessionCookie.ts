import { SessionState } from "../features/session/sessionSlice";

function sessionCookie(user: SessionState) {

    document.cookie = "user=" + JSON.stringify(user);

}

export default sessionCookie;