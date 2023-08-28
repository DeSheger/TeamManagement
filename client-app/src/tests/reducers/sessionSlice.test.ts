import { session } from '../../features/session/sessionSlice';

test('reducers', () => {
  let state;
  state = session({email:'piotr@test.com',name:'Piotr',surrname:'Kowalski',token:"null"});
  expect(state).toEqual({email:'piotr@test.com',name:'Piotr',surrname:'Kowalski',token:'null'});
});