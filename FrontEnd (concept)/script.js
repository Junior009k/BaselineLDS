function validateLogin() {
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    const errorMessage = document.getElementById('errorMessage');

    // Aquí puedes agregar la lógica de validación (ejemplo simple a continuación)
    if (username === 'admin' && password === '1234') {
        alert('Inicio de sesión exitoso');
        errorMessage.textContent = '';
        return true; // Permitir envío del formulario
    } else {
        errorMessage.textContent = 'Usuario o contraseña incorrectos';
        return false; // Evitar envío del formulario
    }
}
