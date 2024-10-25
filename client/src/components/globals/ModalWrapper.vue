<script setup>
defineProps({
    modalId: { type: String, required: true },
    modalTitle: { type: String, default:'Modal title' },
    showFooter:{type:Boolean, default: false}
})
</script>

<template>
    <div class="modal fade" tabindex="-1" aria-hidden="true" :id="modalId" aria-labelledby="modalId + 'Label'">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" :id="modalId + 'Label'">{{modalTitle}}</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <slot></slot>
                </div>
                <div v-if="showFooter" class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancel</button>
                    <button type="button" class="btn btn-primary">Submit</button>
                </div>
            </div>
        </div>
    </div>
</template>

<style lang="scss" scoped></style>