export function ucfirst(text){
    return text.charAt(0).toUpperCase() + text.slice(1);
}

export function formatDuration(sec){    
    const hours = Math.floor(sec / 3600);
    const min = Math.floor((sec % 3600) / 60);
    return hours > 0 
    ? `${hours}h ${min}m` : `${min}m`
}