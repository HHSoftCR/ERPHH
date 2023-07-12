$(document).ready(() => {
    const showAllUser = () => {
        $('#userTable').DataTable({
            ajax: {
                url: '/Home/AllUsers',
                type: 'GET',
                dataType: 'json',
                dataSrc: '',
            },
            columns: [
                { data: 'username', render: formatName },
                { data: 'name', render: formatName },
                { data: 'firstLastname', render: formatName },
                { data: 'secondLastName', render: formatName },
                { data: 'email', render: formatName },
                { data: 'role.name', render: formatName },
                { data: 'subsidiary.name', render: formatName },
                { data: 'status', render: formatName },
            ],
        autoWidth: true
        });
    };

    const formatName = (data, type) => {
        if (type === 'display' && data) {
            const words = data.split(' ');
            const formattedName = words.map((word) => {
                return word.charAt(0).toUpperCase() + word.slice(1).toLowerCase();
            });
            return formattedName.join(' ');
        }
        return data;
    };

    showAllUser();
});
