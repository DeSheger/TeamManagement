import { defineStore } from 'pinia';

export const useAuthenticationData = defineStore('authentication-data', {
	state: () => ({
		name: "",
		surname: "",
		email: "",
		password: ""
	}),
	actions: {
		setName(value: string) {
			this.name = value
            console.log("name has changed")
		},
		setSurname(value: string) {
			this.surname = value
		},
		async setEmail(value: string) {
			this.email = value
            console.log("name has change")
		},
		async setPassword(value: string) {
			this.password = value
		},
	}
});


