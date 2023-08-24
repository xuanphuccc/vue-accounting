<template>
  <div :class="['ms-toast', `--${type}`]">
    <div class="ms-toast__header">
      <MISAIcon icon="check" />
    </div>
    <div class="ms-toast__content">{{ title }}</div>
    <div class="ms-toast__close">
      <MISAIcon :size="20" icon="times" />
    </div>
  </div>
</template>

<script>
import MISAIcon from "../icon/MISAIcon.vue";

export default {
  name: "MISAToast",
  props: {
    // Tiêu đề
    title: {
      type: String,
      default: "Message",
    },

    // Loại toast: info | success | warning | error
    type: {
      type: String,
      default: "info",
    },
  },
  components: {
    MISAIcon,
  },
};
</script>

<style lang="scss" scoped>
.ms-toast {
  display: flex;
  align-items: center;
  min-width: 300px;
  height: 40px;
  background: #ddd;
  border: 1px solid #bbb;
  border-radius: 4px;
}

.ms-toast__content {
  flex: 1;
  padding: 0 12px;
  font-weight: 500;
}

.ms-toast__close {
  margin-right: 8px;
  cursor: pointer;
  color: var(--secondary-text-color);
}

.ms-toast__header {
  flex-shrink: 0;
  display: flex;
  align-items: center;
  justify-content: center;
  width: 40px;
  height: 100%;
  background: #bbb;
}

.ms-toast.--success {
  background: var(--light-green-100);
  border-color: var(--light-green-500);

  .ms-toast__header {
    background: var(--light-green-500);
    color: var(--white);
  }
}

.ms-toast.--info {
  background: var(--blue-100);
  border-color: var(--blue-500);

  .ms-toast__header {
    background: var(--blue-500);
    color: var(--white);
  }
}

.ms-toast.--warning {
  background: var(--orange-100);
  border-color: var(--orange-500);

  .ms-toast__header {
    background: var(--orange-500);
    color: var(--white);
  }
}

.ms-toast.--error {
  background: var(--red-100);
  border-color: var(--red-500);

  .ms-toast__header {
    background: var(--red-500);
    color: var(--white);
  }
}
</style>
